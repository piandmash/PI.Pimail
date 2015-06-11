using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PI.Tests;

using PI.Pimail.Models;

namespace PI.Pimail.Tests
{
    class TestPimailDbSet : TestDbSet<Email>
    {
        public override Email Find(params object[] keyValues)
        {
            return this.SingleOrDefault(email => email.Name == (string)keyValues.Single());
        }
    }

}
