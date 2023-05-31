using System.Globalization;

namespace RCA.Core
{
    public static class ConfigurationHelper
    {
        private static readonly string CONFIGURATION_VALUE_NOT_FOUND_OR_NOT_VALID_FORMAT_WARNING = "Application Setting ({0}) not found or not valid format. Please check.";

        public static void ParseConfigrationValue<T>(string configrationKey, out T configrationValue)
        {
            string configrationValueString = ConfigurationRootHelper.GetConfigurationRoot()[configrationKey];

            if (string.IsNullOrWhiteSpace(configrationValueString))
                throw new Exception(string.Format(CONFIGURATION_VALUE_NOT_FOUND_OR_NOT_VALID_FORMAT_WARNING, configrationKey));

            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Boolean:
                    if (!Boolean.TryParse(configrationValueString, out bool booleanConfigrationValue))
                        throw new Exception(string.Format(CONFIGURATION_VALUE_NOT_FOUND_OR_NOT_VALID_FORMAT_WARNING, configrationKey));
                    configrationValue = (T)(object)booleanConfigrationValue;
                    break;
                case TypeCode.Int32:
                    if (!Int32.TryParse(configrationValueString, out int integerConfigrationValue))
                        throw new Exception(string.Format(CONFIGURATION_VALUE_NOT_FOUND_OR_NOT_VALID_FORMAT_WARNING, configrationKey));
                    configrationValue = (T)(object)integerConfigrationValue;
                    break;
                case TypeCode.String:
                    configrationValue = (T)(object)configrationValueString;
                    break;
                case TypeCode.DateTime:
                    DateTime configrationValueDateTime = DateTime.ParseExact(configrationValueString, "yyyy-M-d", CultureInfo.InvariantCulture);
                    configrationValue = (T)(object)configrationValueDateTime;
                    break;
                default:
                    throw new Exception(string.Format(CONFIGURATION_VALUE_NOT_FOUND_OR_NOT_VALID_FORMAT_WARNING, configrationKey));
            }
        }
    }
}