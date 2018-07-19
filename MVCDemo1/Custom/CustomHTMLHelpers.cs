using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo1.Custom
{
    public class CustomHTMLHelpers
    {
        //This method creates a visualisation of an entity in a * to many relationship
        public static IHtmlString ManyRelationshipField(int ID, string description)
        {
            string _return = "";
            _return = "<div>\n";
            _return += "<label>\n";
            _return += "<button class=\"btn btn-danger\" type=\"button\" onclick=\"deleteAuthor(this)\">\n";
            _return += "BORRAR \n";
            _return += "</button>\n";
            _return += "<input value = \"" + ID + "\" checked=\"checked\" type=\"hidden\" name=\"selectedAuthors\"/>";
            _return += description + "\n";
            _return += "</label>\n";
            _return += "</div>\n";

            return new HtmlString(_return);
        }
    }
}