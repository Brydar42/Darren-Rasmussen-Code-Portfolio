#include "Network.h"
#include <chrono>
int main()
{
	
	try
	{
		WSASession Session;
		UDPSocket Socket;
		char buffer[100];
		std::string input;
		std::cout << "Enter IP Adrress: ";
		std::cin >> input;
		for (int i = 0; i < 101; i++)
		{

			auto timeProduced = std::chrono::duration_cast<std::chrono::milliseconds>(std::chrono::system_clock::now().time_since_epoch()).count();
			
			std::string data = "hello world ";
			data += std::to_string(timeProduced);
			Socket.SendTo(input.c_str(), 100, data.c_str(), data.size());
			Socket.RecvFrom(buffer, 100);

			std::cout << buffer<<std::endl;
		}
	}
	catch (std::exception &ex)
	{
		std::cout << ex.what();
	}
	char c;
	std::cin >> c;
}
