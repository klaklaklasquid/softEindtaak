namespace WeerEventsApi.Logging.Factories;

public static class MetingLoggerFactory
{
    public static IMetingLogger Create(bool decorateWithJson = false, bool decorateWithXml = false)
    {
        //TODO Alle combinaties moeten mogelijk zijn (false,false | true,false | false,true | true,true)
        IMetingLogger logger = new MetingLogger();

        if (decorateWithXml) {
            logger = new XmlMetingLoggerDecorator(logger);
        }
        if (decorateWithJson) {
            logger = new JsonMetingLoggerDecorator(logger);
        }
        return logger;
    }
}