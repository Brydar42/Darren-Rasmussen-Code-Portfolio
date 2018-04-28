#pragma once
#include <iostream>
#include "SimpleModel.h"
#include <vector>
using namespace std;
class ModelManager
{
public:
	ModelManager();
	~ModelManager();
	void store(string name,SimpleModel tostore);//add resource
	string retrevieAdress(SimpleModel atlocation);//resource resorce
	SimpleModel returnResource(string name);
	void removeResorse(string name);
	void wipeResources();
	void inter();
	//
private:
	vector<SimpleModel> modelstorage;
	vector<std::string>modelHandels;
};

ModelManager::ModelManager()
{
}

ModelManager::~ModelManager()
{
	modelstorage.clear();
}

inline void ModelManager::store(string name, SimpleModel tostore)
{
	modelstorage.push_back(tostore);//adds model to storage
	modelHandels.push_back(name);
}

inline string ModelManager::retrevieAdress(SimpleModel atlocation)
{
	bool found=false;
	int count;
	for (count = 0; count < modelstorage.size(); count++)
	{
		if (atlocation==modelstorage.at[count])
		{
			found = true;
			break;
		}
	}
	if (found)
	{
		return modelHandels[count];
	}
	//returnes hadel form model
}

inline SimpleModel ModelManager::returnResource(string name)
{
	bool found = false;
	int count;
	for (count = 0; count < modelHandels.size(); count++)
	{
		if (name == modelHandels.at[count])
		{
			found = true;
			break;
		}
	}
	if (found)
	{
		return modelstorage[count];
	}
	//takes handle and reterns resource
}

inline void ModelManager::removeResorse(string name)
{
	bool found = false;
	int count;
	for (count = 0; count < modelHandels.size(); count++)
	{
		if (name == modelHandels.at[count])
		{
			found = true;
			break;
		}
	}
	if (found)
	{
		//modelstorage.erase(count);
	}
	//remove item with this name
}

inline void ModelManager::wipeResources()
{
	modelHandels.clear();
	modelstorage.clear();
	//clear
}

inline void ModelManager::inter()
{
	//goes though the map
}
