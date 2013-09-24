using System.Linq;
using PharmAssist.Core.Data.Entities.Settings;

namespace PharmAssist.Core.Data.Collection.SettingCollection
{
    /// <summary>
    /// Base class for setting collection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SettingCollection<T> : EntityCollection<T> where T : SettingBase
    {
        /// <summary>
        /// Gets the setting value.
        /// </summary>
        /// <param name="settingName">Name of the setting.</param>
        /// <returns>Setting value</returns>
        public string GetSettingValue(string settingName)
        {
            T t = Items.FirstOrDefault(T => T.SettingName == settingName);
            if (t != null)
            {
                return t.SettingValue;
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the setting value.
        /// </summary>
        /// <param name="settingName">Name of the setting.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>Setting value</returns>
        public string GetSettingValue(string settingName, string defaultValue)
        {
            T t = Items.FirstOrDefault(T => T.SettingName == settingName);
            if (t != null)
            {
                if (!string.IsNullOrEmpty(t.SettingValue))
                {
                    return t.SettingValue;
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Determines whether the given setting name exists.
        /// </summary>
        /// <param name="settingName">Name of the setting.</param>
        /// <returns>
        /// true if the specified setting name has setting; otherwise, false.
        /// </returns>
        public bool HasSetting(string settingName)
        {
            bool hasSetting = false;
            T t = Items.FirstOrDefault(T => T.SettingName == settingName);
            if (t != null)
            {
                hasSetting = true;
            }

            return hasSetting;
        }
    }
}
