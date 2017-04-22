﻿using Mono.Cecil;

public class AttributeFinder
{
    public AttributeFinder(MethodDefinition method)
    {
        var customAttributes = method.CustomAttributes;
        if (customAttributes.ContainsAttribute("Anotar.Custom.LogToTraceOnExceptionAttribute"))
        {
            FoundTrace = true;
            Found = true;
        }
        if (customAttributes.ContainsAttribute("Anotar.Custom.LogToDebugOnExceptionAttribute"))
        {
            FoundDebug = true;
            Found = true;
        }
        if (customAttributes.ContainsAttribute("Anotar.Custom.LogToInformationOnExceptionAttribute"))
        {
            FoundInformation = true;
            Found = true;
        }
        if (customAttributes.ContainsAttribute("Anotar.Custom.LogToWarningOnExceptionAttribute"))
        {
            FoundWarning = true;
            Found = true;
        }
        if (customAttributes.ContainsAttribute("Anotar.Custom.LogToErrorOnExceptionAttribute"))
        {
            FoundError = true;
            Found = true;
        }
        if (customAttributes.ContainsAttribute("Anotar.Custom.LogToFatalOnExceptionAttribute"))
        {
            FoundFatal = true;
            Found = true;
        }

    }

    public bool Found;
    public bool FoundInformation;
    public bool FoundTrace;
    public bool FoundDebug;
    public bool FoundWarning;
    public bool FoundError;
    public bool FoundFatal;
}