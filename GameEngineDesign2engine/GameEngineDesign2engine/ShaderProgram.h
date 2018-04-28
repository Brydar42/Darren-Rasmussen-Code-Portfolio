#pragma once
#include "ShaderVariable.h"
class ShaderProgram
{
public:
	ShaderProgram();
	~ShaderProgram();
	void addVertexShader(ShaderVariable newShader);
	void addFragmentShader(ShaderVariable newShader);
	void eraseAll();
private:
	/** The list of all variables for the vertexShader */
	std::vector<ShaderVariable>					vertexVariables;
	/** The list of all variables for the fragmentShader */
	std::vector<ShaderVariable>					fragmentVariables;
	/** The name for the shader program */
	std::string									programName;
	/** This will be true if the shader components are runnable and the shader program is compiled and runnable */
	bool										runnable = false;
};

ShaderProgram::ShaderProgram()
{
}

ShaderProgram::~ShaderProgram()
{
}

inline void ShaderProgram::addVertexShader(ShaderVariable newShader)
{
	vertexVariables.push_back(newShader);
}
inline void ShaderProgram::addFragmentShader(ShaderVariable newShader)
{
	fragmentVariables.push_back(newShader);
}
inline void ShaderProgram::eraseAll()
{
	vertexVariables.clear();
	fragmentVariables.clear();
	programName = NAN;
	runnable = false;
}