namespace BookStore.Helpers
{
    public static class ExtensionsMethods
    {
        /// <summary>
        /// Check Null or White Space.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsBlank(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// Check not Null and White Space.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotBlank(this string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }
    }
}
