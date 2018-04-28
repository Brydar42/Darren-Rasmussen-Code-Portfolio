#ifndef Model_H
#define Model_H
#include <iostream>
#include <vector>
class SimpleModel
{
public:
	SimpleModel();
	~SimpleModel();
	void SetPosition(float x, float y, float z);
	void Setcolour(int R, int G, int B, int A);
	void SetNormal(float x, float y, float z);
	void SetUV(float U, float V);
	void SetEverything(float x, float y, float z, int R, int G, int B, int A, float nx, float ny, float nz, float U, float V);
	void directXSend();
private:
	float position[3];
	int colour[4];
	float normal[3];
	float uvcorodentis[2];
};

SimpleModel::SimpleModel()
{
}

SimpleModel::~SimpleModel()
{
}

inline void SimpleModel::SetPosition(float x, float y, float z)
{
	position[0] = x;
	position[1] = y;
	position[2] = z;
}

inline void SimpleModel::Setcolour(int R, int G, int B, int A)
{
	colour[0] = R;
	colour[1] = G;
	colour[2] = B;
	colour[3] = A;
}

inline void SimpleModel::SetNormal(float x, float y, float z)
{
	normal[0] = x;
	normal[1] = y;
	normal[2] = z;
}

inline void SimpleModel::SetUV(float U, float V)
{
	uvcorodentis[0] = U;
	uvcorodentis[1] = V;
}

inline void SimpleModel::SetEverything(float x, float y, float z, int R, int G, int B, int A, float nx, float ny, float nz, float U, float V)
{
	position[0] = x;
	position[1] = y;
	position[2] = z;
	colour[0] = R;
	colour[1] = G;
	colour[2] = B;
	colour[3] = A;
	normal[0] = x;
	normal[1] = y;
	normal[2] = z;
	uvcorodentis[0] = U;
	uvcorodentis[1] = V;
}



inline void SimpleModel::directXSend()
{
	//Position[0],Position[1],Position[2],colour[0],colour[1],colour[2],colour[3],normal[0],normal[1],normal[2],uvcorodentis[0],uvcorodentis[1]
}
//position,colour,normal,uv
#endif // !Model_H

