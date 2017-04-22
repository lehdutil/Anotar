using System.Linq;
using Mono.Cecil;

public partial class ModuleWeaver
{
    public void Init()
    {
        var logManagerType = CatelReference.MainModule.Types.First(x => x.Name == "LogManager");
        var getLoggerMethod = logManagerType.FindMethod("GetLogger", "Type");
        constructLoggerMethod = ModuleDefinition.ImportReference(getLoggerMethod);
        var loggerTypeDefinition = CatelReference.MainModule.Types.First(x => x.Name == "ILog");
        LoggerType = ModuleDefinition.ImportReference(loggerTypeDefinition);
        var logEventDefinition = CatelReference.MainModule.Types.First(x => x.Name == "LogEvent");
        DebugLogEvent = (int) logEventDefinition.Fields.First(x => x.Name == "Debug").Constant;
        ErrorLogEvent = (int) logEventDefinition.Fields.First(x => x.Name == "Error").Constant;
        InfoLogEvent = (int) logEventDefinition.Fields.First(x => x.Name == "Info").Constant;
        WarningLogEvent = (int) logEventDefinition.Fields.First(x => x.Name == "Warning").Constant;

        WriteMethod = ModuleDefinition.ImportReference(
            loggerTypeDefinition.FindMethod("WriteWithData", "String", "Object", "LogEvent"));
        WriteExceptionMethod =
            ModuleDefinition.ImportReference(
                loggerTypeDefinition.FindMethod("WriteWithData", "Exception", "String", "Object", "LogEvent"));

        var logInfoDefinition = logManagerType.NestedTypes.First(x => x.Name == "LogInfo");
        IsDebugEnabledMethod = ModuleDefinition.ImportReference(logInfoDefinition.FindMethod("get_IsDebugEnabled"));
        IsErrorEnabledMethod = ModuleDefinition.ImportReference(logInfoDefinition.FindMethod("get_IsErrorEnabled"));
        IsWarningEnabledMethod = ModuleDefinition.ImportReference(logInfoDefinition.FindMethod("get_IsWarningEnabled"));
        IsInfoEnabledMethod = ModuleDefinition.ImportReference(logInfoDefinition.FindMethod("get_IsInfoEnabled"));
    }

    public int WarningLogEvent;
    public int InfoLogEvent;
    public int ErrorLogEvent;
    public int DebugLogEvent;

    public MethodReference WriteMethod;
    public MethodReference WriteExceptionMethod;

    public TypeReference LoggerType;

    MethodReference constructLoggerMethod;
    public MethodReference IsDebugEnabledMethod;
    public MethodReference IsInfoEnabledMethod;
    public MethodReference IsWarningEnabledMethod;
    public MethodReference IsErrorEnabledMethod;

}