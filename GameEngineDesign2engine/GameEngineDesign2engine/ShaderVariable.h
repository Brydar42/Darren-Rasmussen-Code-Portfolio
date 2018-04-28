#pragma once
#include <iostream>
#include <vector>
#include <glew.h>
class ShaderVariable
{
public:
	enum VariableAccessType {
		ACCESS_NONE = 0,
		ACCESS_IN,
		ACCESS_OUT,
		ACCESS_INOUT
	};
	enum ShaderVariableType {
		SHADER_VAR_NONE = 0,
		SHADER_VAR_UNIFORM,
		SHADER_VAR_ATTRIBUTE,
		SHADER_VAR_VARYING
	};
private:
	/** The resource name for this shader variable */
	std::string			name;
	/** The name of the variable used within the shader programs */
	std::string			sourceName;
	/** Whether the variable is IN, OUT or INOUT */
	VariableAccessType	accessType;
	/** whether the variable is vertex, uniform or varying */
	ShaderVariableType	variableType;
public:
	VariableAccessType getAccessType()
	{
		return accessType;
	}
	ShaderVariableType getVariableTybe()
	{
		return variableType;
	}
	std::string getSourceName()
	{
		return sourceName;
	}
	void setAccessType(VariableAccessType newAccess)
	{
		accessType = newAccess;
	}
	void setShaderVariableType(ShaderVariableType newVariable)
	{
		variableType = newVariable;
	}
	void setSourceName(std::string newSource)
	{
		sourceName = newSource;
	}
	void setName(std::string newName)
	{
		name = newName;
	}
};