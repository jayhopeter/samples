//-----------------------------------------------------------------------------
// <auto-generated> 
//   This code was generated by a tool. 
// 
//   Changes to this file may cause incorrect behavior and will be lost if  
//   the code is regenerated.
//
//   Tool: AllJoynCodeGenerator.exe
//
//   This tool is located in the Windows 10 SDK and the Windows 10 AllJoyn 
//   Visual Studio Extension in the Visual Studio Gallery.  
//
//   The generated code should be packaged in a Windows 10 C++/CX Runtime  
//   Component which can be consumed in any UWP-supported language using 
//   APIs that are available in Windows.Devices.AllJoyn.
//
//   Using AllJoynCodeGenerator - Invoke the following command with a valid 
//   Introspection XML file and a writable output directory:
//     AllJoynCodeGenerator -i <INPUT XML FILE> -o <OUTPUT DIRECTORY>
// </auto-generated>
//-----------------------------------------------------------------------------
#pragma once

using namespace concurrency;

namespace com { namespace microsoft { namespace ZWaveBridge { namespace SwitchBinary { namespace Switch {

ref class SwitchConsumer;

public ref class SwitchJoinSessionResult sealed
{
public:
    property int32 Status
    {
        int32 get() { return m_status; }
    internal:
        void set(_In_ int32 value) { m_status = value; }
    }

    property SwitchConsumer^ Consumer
    {
        SwitchConsumer^ get() { return m_consumer; }
    internal:
        void set(_In_ SwitchConsumer^ value) { m_consumer = value; }
    };

private:
    int32 m_status;
    SwitchConsumer^ m_consumer;
};

public ref class SwitchGetGenreResult sealed
{
public:
    property int32 Status
    {
        int32 get() { return m_status; }
    internal:
        void set(_In_ int32 value) { m_status = value; }
    }

    property Platform::String^ Genre
    {
        Platform::String^ get() { return m_value; }
    internal:
        void set(_In_ Platform::String^ value) { m_value = value; }
    }

    static SwitchGetGenreResult^ CreateSuccessResult(_In_ Platform::String^ value)
    {
        auto result = ref new SwitchGetGenreResult();
        result->Status = Windows::Devices::AllJoyn::AllJoynStatus::Ok;
        result->Genre = value;
        result->m_creationContext = Concurrency::task_continuation_context::use_current();
        return result;
    }

    static SwitchGetGenreResult^ CreateFailureResult(_In_ int32 status)
    {
        auto result = ref new SwitchGetGenreResult();
        result->Status = status;
        return result;
    }
internal:
    Concurrency::task_continuation_context m_creationContext = Concurrency::task_continuation_context::use_default();

private:
    int32 m_status;
    Platform::String^ m_value;
};

public ref class SwitchGetHelpResult sealed
{
public:
    property int32 Status
    {
        int32 get() { return m_status; }
    internal:
        void set(_In_ int32 value) { m_status = value; }
    }

    property Platform::String^ Help
    {
        Platform::String^ get() { return m_value; }
    internal:
        void set(_In_ Platform::String^ value) { m_value = value; }
    }

    static SwitchGetHelpResult^ CreateSuccessResult(_In_ Platform::String^ value)
    {
        auto result = ref new SwitchGetHelpResult();
        result->Status = Windows::Devices::AllJoyn::AllJoynStatus::Ok;
        result->Help = value;
        result->m_creationContext = Concurrency::task_continuation_context::use_current();
        return result;
    }

    static SwitchGetHelpResult^ CreateFailureResult(_In_ int32 status)
    {
        auto result = ref new SwitchGetHelpResult();
        result->Status = status;
        return result;
    }
internal:
    Concurrency::task_continuation_context m_creationContext = Concurrency::task_continuation_context::use_default();

private:
    int32 m_status;
    Platform::String^ m_value;
};

public ref class SwitchGetIndexResult sealed
{
public:
    property int32 Status
    {
        int32 get() { return m_status; }
    internal:
        void set(_In_ int32 value) { m_status = value; }
    }

    property int32 Index
    {
        int32 get() { return m_value; }
    internal:
        void set(_In_ int32 value) { m_value = value; }
    }

    static SwitchGetIndexResult^ CreateSuccessResult(_In_ int32 value)
    {
        auto result = ref new SwitchGetIndexResult();
        result->Status = Windows::Devices::AllJoyn::AllJoynStatus::Ok;
        result->Index = value;
        result->m_creationContext = Concurrency::task_continuation_context::use_current();
        return result;
    }

    static SwitchGetIndexResult^ CreateFailureResult(_In_ int32 status)
    {
        auto result = ref new SwitchGetIndexResult();
        result->Status = status;
        return result;
    }
internal:
    Concurrency::task_continuation_context m_creationContext = Concurrency::task_continuation_context::use_default();

private:
    int32 m_status;
    int32 m_value;
};

public ref class SwitchGetInstanceResult sealed
{
public:
    property int32 Status
    {
        int32 get() { return m_status; }
    internal:
        void set(_In_ int32 value) { m_status = value; }
    }

    property int32 Instance
    {
        int32 get() { return m_value; }
    internal:
        void set(_In_ int32 value) { m_value = value; }
    }

    static SwitchGetInstanceResult^ CreateSuccessResult(_In_ int32 value)
    {
        auto result = ref new SwitchGetInstanceResult();
        result->Status = Windows::Devices::AllJoyn::AllJoynStatus::Ok;
        result->Instance = value;
        result->m_creationContext = Concurrency::task_continuation_context::use_current();
        return result;
    }

    static SwitchGetInstanceResult^ CreateFailureResult(_In_ int32 status)
    {
        auto result = ref new SwitchGetInstanceResult();
        result->Status = status;
        return result;
    }
internal:
    Concurrency::task_continuation_context m_creationContext = Concurrency::task_continuation_context::use_default();

private:
    int32 m_status;
    int32 m_value;
};

public ref class SwitchGetLabelResult sealed
{
public:
    property int32 Status
    {
        int32 get() { return m_status; }
    internal:
        void set(_In_ int32 value) { m_status = value; }
    }

    property Platform::String^ Label
    {
        Platform::String^ get() { return m_value; }
    internal:
        void set(_In_ Platform::String^ value) { m_value = value; }
    }

    static SwitchGetLabelResult^ CreateSuccessResult(_In_ Platform::String^ value)
    {
        auto result = ref new SwitchGetLabelResult();
        result->Status = Windows::Devices::AllJoyn::AllJoynStatus::Ok;
        result->Label = value;
        result->m_creationContext = Concurrency::task_continuation_context::use_current();
        return result;
    }

    static SwitchGetLabelResult^ CreateFailureResult(_In_ int32 status)
    {
        auto result = ref new SwitchGetLabelResult();
        result->Status = status;
        return result;
    }
internal:
    Concurrency::task_continuation_context m_creationContext = Concurrency::task_continuation_context::use_default();

private:
    int32 m_status;
    Platform::String^ m_value;
};

public ref class SwitchGetMaxResult sealed
{
public:
    property int32 Status
    {
        int32 get() { return m_status; }
    internal:
        void set(_In_ int32 value) { m_status = value; }
    }

    property int32 Max
    {
        int32 get() { return m_value; }
    internal:
        void set(_In_ int32 value) { m_value = value; }
    }

    static SwitchGetMaxResult^ CreateSuccessResult(_In_ int32 value)
    {
        auto result = ref new SwitchGetMaxResult();
        result->Status = Windows::Devices::AllJoyn::AllJoynStatus::Ok;
        result->Max = value;
        result->m_creationContext = Concurrency::task_continuation_context::use_current();
        return result;
    }

    static SwitchGetMaxResult^ CreateFailureResult(_In_ int32 status)
    {
        auto result = ref new SwitchGetMaxResult();
        result->Status = status;
        return result;
    }
internal:
    Concurrency::task_continuation_context m_creationContext = Concurrency::task_continuation_context::use_default();

private:
    int32 m_status;
    int32 m_value;
};

public ref class SwitchGetMinResult sealed
{
public:
    property int32 Status
    {
        int32 get() { return m_status; }
    internal:
        void set(_In_ int32 value) { m_status = value; }
    }

    property int32 Min
    {
        int32 get() { return m_value; }
    internal:
        void set(_In_ int32 value) { m_value = value; }
    }

    static SwitchGetMinResult^ CreateSuccessResult(_In_ int32 value)
    {
        auto result = ref new SwitchGetMinResult();
        result->Status = Windows::Devices::AllJoyn::AllJoynStatus::Ok;
        result->Min = value;
        result->m_creationContext = Concurrency::task_continuation_context::use_current();
        return result;
    }

    static SwitchGetMinResult^ CreateFailureResult(_In_ int32 status)
    {
        auto result = ref new SwitchGetMinResult();
        result->Status = status;
        return result;
    }
internal:
    Concurrency::task_continuation_context m_creationContext = Concurrency::task_continuation_context::use_default();

private:
    int32 m_status;
    int32 m_value;
};

public ref class SwitchGetUnitsResult sealed
{
public:
    property int32 Status
    {
        int32 get() { return m_status; }
    internal:
        void set(_In_ int32 value) { m_status = value; }
    }

    property Platform::String^ Units
    {
        Platform::String^ get() { return m_value; }
    internal:
        void set(_In_ Platform::String^ value) { m_value = value; }
    }

    static SwitchGetUnitsResult^ CreateSuccessResult(_In_ Platform::String^ value)
    {
        auto result = ref new SwitchGetUnitsResult();
        result->Status = Windows::Devices::AllJoyn::AllJoynStatus::Ok;
        result->Units = value;
        result->m_creationContext = Concurrency::task_continuation_context::use_current();
        return result;
    }

    static SwitchGetUnitsResult^ CreateFailureResult(_In_ int32 status)
    {
        auto result = ref new SwitchGetUnitsResult();
        result->Status = status;
        return result;
    }
internal:
    Concurrency::task_continuation_context m_creationContext = Concurrency::task_continuation_context::use_default();

private:
    int32 m_status;
    Platform::String^ m_value;
};

public ref class SwitchGetValueResult sealed
{
public:
    property int32 Status
    {
        int32 get() { return m_status; }
    internal:
        void set(_In_ int32 value) { m_status = value; }
    }

    property bool Value
    {
        bool get() { return m_value; }
    internal:
        void set(_In_ bool value) { m_value = value; }
    }

    static SwitchGetValueResult^ CreateSuccessResult(_In_ bool value)
    {
        auto result = ref new SwitchGetValueResult();
        result->Status = Windows::Devices::AllJoyn::AllJoynStatus::Ok;
        result->Value = value;
        result->m_creationContext = Concurrency::task_continuation_context::use_current();
        return result;
    }

    static SwitchGetValueResult^ CreateFailureResult(_In_ int32 status)
    {
        auto result = ref new SwitchGetValueResult();
        result->Status = status;
        return result;
    }
internal:
    Concurrency::task_continuation_context m_creationContext = Concurrency::task_continuation_context::use_default();

private:
    int32 m_status;
    bool m_value;
};

public ref class SwitchSetValueResult sealed
{
public:
    property int32 Status
    {
        int32 get() { return m_status; }
    internal:
        void set(_In_ int32 value) { m_status = value; }
    }

    static SwitchSetValueResult^ CreateSuccessResult()
    {
        auto result = ref new SwitchSetValueResult();
        result->Status = Windows::Devices::AllJoyn::AllJoynStatus::Ok;
        result->m_creationContext = Concurrency::task_continuation_context::use_current();
        return result;
    }

    static SwitchSetValueResult^ CreateFailureResult(_In_ int32 status)
    {
        auto result = ref new SwitchSetValueResult();
        result->Status = status;
        return result;
    }
internal:
    Concurrency::task_continuation_context m_creationContext = Concurrency::task_continuation_context::use_default();

private:
    int32 m_status;
};

} } } } } 
