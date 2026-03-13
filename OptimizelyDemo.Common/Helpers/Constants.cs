
namespace OptimizelyDemo.Common.Helpers
{
    public class Constants
    {
        public const string PageViewLocation = "~/Views/Page.cshtml";
        public const string ComponentsViewLocation = "~/Views/Partials/Components";
        public const string GlobalViewLocation = "~/Views/Partials/Global";
        public const string LayoutViewLocation = "~/Views/Layout.cshtml";

        public static class Cms
        {
            public const string CurrentLanguage = "CurrentLanguage";
            public const string ComponentViewLocation = "~/Views/Partials/Components/";
            
            public static class ContentTypes
            {
                public const string MediaCentres = "Newsroom";
                public const string Events = "Events";
                public const string Residences = "Residencies";
            }

            public static class Fields
            {
                public const string Heading = "Heading";
            }

            public static class Languages
            {
                public const string Default = "en";
            }
        }
    }
}
