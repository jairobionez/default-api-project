using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultProject.Application.ViewModel.UserViewModel
{
    public class UserRequestViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }
    }
}