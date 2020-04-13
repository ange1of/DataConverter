using System;
using Newtonsoft.Json;

namespace project {

    public class JsonValidator: DataValidator {
        public override bool validate(string document) {
            try {
                JsonConvert.DeserializeObject(document);
                return true;
            }
            catch (JsonReaderException) {
                return false;
            }
        }
    }

}