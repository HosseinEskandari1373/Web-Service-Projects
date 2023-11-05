using DocumentFormat.OpenXml.Office2013.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSurvey.Models.FormSettings
{
    public class FormSettings
    {
        public Surveys survey { get; set; }
        public bool authentication_needed { get; set; }
        public bool porsline_auth { get; set; }
        public bool porsline_auth_no_spam { get; set; }
        public List<string> porsline_auth_domains { get; set; }
        public bool code_auth { get; set; }
        public bool code_auth_is_unique { get; set; }
        public string code_authentication_file_name { get; set; }
        public string auth_description { get; set; }
        public bool captcha_needed { get; set; }
        public bool hidden_responder_details { get; set; }
        public bool privacy_preserving_message_enabled { get; set; }
        public bool no_spam { get; set; }
        public bool tag_spam { get; set; }
        public bool location_is_active { get; set; }
        public bool location_is_required { get; set; }
        public string location_description { get; set; }
        public bool hide_next_button { get; set; }
        public bool hide_previous_button { get; set; }
        public bool hide_progressbar { get; set; }
        public string expiration_date { get; set; }

        [JsonProperty("responding_ duration")]
        public string RespondingDuration { get; set; }
        public bool edit_response_enabled { get; set; }
        public bool branding_removal { get; set; }
    }
}
