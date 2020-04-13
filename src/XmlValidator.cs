using System;
using System.Xml.Linq;

namespace project {

    public class XmlValidator: DataValidator {
        public override bool validate(string document) {
            try {
                XDocument.Parse(document);
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
    }

}