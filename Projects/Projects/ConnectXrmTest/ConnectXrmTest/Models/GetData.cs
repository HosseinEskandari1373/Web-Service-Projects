using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectXRM_Test
{
    class GetData
    {
        /*Credentials*/
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid Id { get; set; }

        /*Contact*/
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        /*Account*/
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
