using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Collections;
using System.Net.Mail;
using System.Net.Mime;
using System.ComponentModel;

using PI.Pimail.Models;

namespace PI.Pimail
{
    /// <markdown>
    /// #PI.Pimail.Mail
    /// File: Mail.cs
    /// </markdown>
    /// <summary>
    /// Default Mail Class using the IMail interface
    /// </summary>
    public class Mail : IMail
    {

        #region Properties

        /// <markdown>
        /// ###public string TagStart
        /// </markdown>
        /// <summary>
        /// The start tag used as a placeholder
        /// </summary>
        public string TagStart { get; set; }

        /// <markdown>
        /// ###public string TagEnd
        /// </markdown>
        /// <summary>
        /// The end tag used as a placeholder
        /// </summary>
        public string TagEnd { get; set; }

        /// <markdown>
        /// ###public string FileRoot
        /// </markdown>
        /// <summary>
        /// The root folder for any file attachments
        /// </summary>
        public string FileRoot { get; set; }

        /// <markdown>
        /// ###private Email m_LastSentEmail
        /// </markdown>
        /// <summary>
        /// Internally stores a reference to the last email sent via the object
        /// </summary>
        private Email m_LastSentEmail = null;

        /// <markdown>
        /// ###public Email LastSentEmail
        /// </markdown>
        /// <summary>
        /// Returns the last email sent via the object, get only
        /// </summary>
        public Email LastSentEmail {
            get { return m_LastSentEmail; }
        }

        #endregion

        #region Constructors

        /// <markdown>
        /// ###public Mail(string fileRoot)
        /// </markdown>
        /// <summary>
        /// Default empty constructor with as used in live requests
        /// </summary>
        public Mail()
        {
            FileRoot = "";
            TagStart = "[";
            TagEnd = "]";
        }


        /// <markdown>
        /// ###public Mail(string fileRoot)
        /// </markdown>
        /// <summary>
        /// Constructor with a file root set on creation, to allow for context for testing
        /// </summary>
        /// <param name="fileRoot">The fileRoot as a string</param>
        public Mail(string fileRoot)
        {
            FileRoot = fileRoot;
            TagStart = "[";
            TagEnd = "]";
        }

        #endregion


        #region Methods: Hash Table

        private Hashtable m_ht = new Hashtable();

        /// <markdown>
        /// ###public void Add(object key, object value)
        /// </markdown>
        /// <summary>
        /// Adds a key and it's value to the Hash Table
        /// </summary>
        /// <param name="key"></param>
        /// <param name="Value"></param>
        public void Add(object key, object value)
        {
            m_ht.Add(key, value);
        }

        /// <markdown>
        /// ###public void Remove(object key)
        /// </markdown>
        /// <summary>
        /// Removes a key pair from the hash table
        /// </summary>
        /// <param name="key">Key to remove</param>
        public void Remove(object key)
        {
            m_ht.Remove(key);
        }

        /// <markdown>
        /// ###public void Clear()
        /// </markdown>
        /// <summary>
        /// Clears the hash table
        /// </summary>
        public void Clear()
        {
            m_ht.Clear();
        }

        /// <markdown>
        /// ###public void AddObject(object itemToAdd, string prefix = "")
        /// </markdown>
        /// <summary>
        /// Adds in bulk object properties to an email.
        /// The prefix should be added to the email parameters
        /// in the xml email body
        /// e.g. [PRIZE_DISPLAYNAME] where prefix is "PRIZE_"
        /// </summary>
        /// <param name="itemToAdd"></param>
        /// <param name="prefix">The parameters are prefixed with this to avoid duplicate addding of values such as id</param>
        public void AddObject(object itemToAdd, string prefix = "")
        {
            Type t = itemToAdd.GetType();
            foreach (PropertyInfo field in t.GetProperties())
            {
                var val = field.GetValue(itemToAdd, null);
                if (field.PropertyType.IsValueType || field.PropertyType == typeof(string))
                {
                    Add(prefix + field.Name.ToUpper(), val);
                }
                else if (val == null)
                {
                    Add(prefix + field.Name.ToUpper(), "");
                }
                else
                {
                    if (IsIEnumerable(val.GetType())) Add(prefix + field.Name.ToUpper(), val);
                }
            }
        }

        /// <markdown>
        /// ###private bool IsIEnumerable(Type someType)
        /// </markdown>
        /// <summary>
        /// Checks if a type is IEnumerable
        /// </summary>
        /// <param name="someType">The type to check for IEnumerable</param>
        /// <returns>true if the object is IEnumerable else returns false even on Exception</returns>
        private bool IsIEnumerable(Type someType)
        {
            try
            {
                if (someType.IsValueType || someType == typeof(string)) return false;

                Type[] listInterfaces = someType.GetInterfaces();
                foreach (Type t in listInterfaces)
                {
                    try
                    {
                        if (t.GetGenericTypeDefinition() == typeof(IEnumerable<>)) return true;
                    }
                    catch { }
                    try
                    {
                        if (t == typeof(IEnumerable<>)) return true;
                    }
                    catch { }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion

        #region Methods: Build

        /// <markdown>
        /// ###public MailMessage BuildMailMessage(Email email)
        /// </markdown>
        /// <summary>
        /// Builds a mail message from the email object sent with the hash table values replaced
        /// </summary>
        /// <param name="email">The email to create the mail message from</param>
        /// <returns>New MailMessage</returns>
        public MailMessage BuildMailMessage(Email email)
        {
            try
            {
                //create a clone of this object
                Email em = new Email()
                {
                    Name = email.Name,
                    To = ReplaceDynamicText(email.To),
                    Subject = ReplaceDynamicText(email.Subject),
                    BodyHtml = ReplaceDynamicText(email.BodyHtml),
                    BodyPlain = ReplaceDynamicText(email.BodyPlain),
                    IsBodyHtml = email.IsBodyHtml,
                    From = ReplaceDynamicText(email.From),
                    FromDisplay = ReplaceDynamicText(email.FromDisplay),
                    Cc = ReplaceDynamicText(email.Cc),
                    Bcc = ReplaceDynamicText(email.Bcc),
                    FilesToAttach = email.FilesToAttach,
                    ContentEncoding = email.ContentEncoding,
                    HeaderEncoding = email.HeaderEncoding,
                    AdditionalHeaders = email.AdditionalHeaders,
                    Priority = email.Priority,
                    ReplyTo = ReplaceDynamicText(email.ReplyTo)
                };

                // Create email message with default email address
                MailMessage mail = new MailMessage(em.From, em.From);

                // Set Email From
                mail.From = (!String.IsNullOrEmpty(em.FromDisplay)) ? new MailAddress(em.From, em.FromDisplay) : new MailAddress(em.From);

                // Clear and set Email To
                mail.To.Clear();
                SetAddresses(mail.To, em.To);

                // Check for and set Carbon Copy recipients
                if (!String.IsNullOrEmpty(em.Cc)) SetAddresses(mail.CC, em.Cc);

                // Check for and set Blind Carbon Copy recipients
                if (!String.IsNullOrEmpty(em.Bcc)) SetAddresses(mail.Bcc, em.Bcc);

                // Set Subject
                mail.Subject = em.Subject;

                // Check if plain text version specified
                if (em.IsBodyHtml && !String.IsNullOrEmpty(em.BodyPlain))
                {
                    // PLAIN TEXT VERSION
                    AlternateView plainTextView = AlternateView.CreateAlternateViewFromString(em.BodyPlain, null, MediaTypeNames.Text.Plain);
                    mail.AlternateViews.Add(plainTextView);
                }

                // HTML TEXT VERSION                
                mail.Body = (em.IsBodyHtml) ? em.BodyHtml : em.BodyPlain;
                mail.BodyEncoding = Encoding.GetEncoding(em.ContentEncoding);
                mail.IsBodyHtml = em.IsBodyHtml;

                if (em.IsBodyHtml && !String.IsNullOrEmpty(em.BodyHtml))
                {
                    // HTML VERSION
                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(em.BodyHtml, null, MediaTypeNames.Text.Html);
                    mail.AlternateViews.Add(htmlView);
                }

                mail.HeadersEncoding = Encoding.GetEncoding(em.HeaderEncoding);
                //if (!String.IsNullOrEmpty(em.AdditionalHeaders)) mail.Headers

                if (em.FilesToAttach != null) {
                    // Attachment
                    foreach (string file in em.FilesToAttach)
                    {
                        string path = FileRoot + file;
                        // Check if file exists
                        if (File.Exists(path))
                        {
                            // Attach file to message
                            Attachment messageAttachment = new Attachment(path);
                            mail.Attachments.Add(messageAttachment);
                        }
                    }
                }

                return mail;
            }
            catch
            {
                throw;
            }
        }

        /// <markdown>
        /// ###private void SetAddresses(MailAddressCollection mac, string addresses)
        /// </markdown>
        /// <summary>
        /// Sets email address collection from semi-colon seperated address string
        /// </summary>
        /// <param name="mac">Email Address Collection</param>
        /// <param name="addresses">Semi-colon seperated Email Addresses</param>
        private void SetAddresses(MailAddressCollection mac, string addresses)
        {
            try
            {
                foreach (string add in addresses.Split(';'))
                {
                    if (!add.StartsWith("[") && !add.EndsWith("]")) mac.Add(new MailAddress(add));
                }
            }
            catch { }
        }

        #endregion


        #region Methods: Merging

        /// <markdown>
        /// ###private string ReplaceDynamicText(string t, Hashtable h = null)
        /// </markdown>
        /// <summary>
        /// Replaces text based on a hash table
        /// </summary>
        /// <param name="t">String</param>
        /// <param name="h">Hash Table</param>
        /// <returns>String</returns>
        private string ReplaceDynamicText(string t, Hashtable h = null)
        {
            if (String.IsNullOrEmpty(t)) return t;
            if (h == null) h = m_ht;
            foreach (object k in h.Keys)
            {
                if (h[k] != null && IsIEnumerable(h[k].GetType()))
                {
                    string start = TagStart + k.ToString().ToUpper() + "_START" + TagEnd;
                    string end = TagStart + k.ToString().ToUpper() + "_END" + TagEnd;
                    //get template between key and _START and _END
                    int s = t.IndexOf(start, 0);
                    int e = t.IndexOf(end, 0);
                    if (s > -1 && e > s)
                    {
                        string template = t.Substring(s, e - s);
                        string str = "";
                        IEnumerable enumerable = (h[k] as IEnumerable);
                        foreach (var item in enumerable)
                        {
                            //add new line to the template
                            str += template;
                            //replace item
                            str = ReplaceDynamicText(str, item);
                        }
                        //replace entire template 
                        t = t.Replace(template, str).Replace(start, "").Replace(end, "");
                    }
                } else {
                    var val = (h[k] != null) ? h[k].ToString() : "";
                    t = t.Replace(TagStart + k.ToString().ToUpper() + TagEnd, val);
                }
            }
            return t;
        }

        /// <markdown>
        /// ###private string ReplaceDynamicText(string t, object o)
        /// </markdown>
        /// <summary>
        /// Replaces text based on the object sent
        /// </summary>
        /// <param name="t">Text</param>
        /// <param name="o">Object</param>
        /// <returns>String</returns>
        private string ReplaceDynamicText(string t, object o)
        {
            Type tp = o.GetType();
            FieldInfo[] fs = tp.GetFields(BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < fs.Length; i++)
            {
                var prp = fs[i].GetValue(o);
                var val = (prp != null) ? prp.ToString() : "";
                t = t.Replace(TagStart + fs[i].Name.ToUpper() + TagEnd, val);
            }
            //for generics
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(o);
            foreach (PropertyDescriptor prop in props)
            {
                var prp = prop.GetValue(o);
                var val = (prp != null) ? prp.ToString() : "";
                t = t.Replace(TagStart + prop.Name.ToUpper() + TagEnd, val);
            }
            return t;
        }

        #endregion
    }
}
