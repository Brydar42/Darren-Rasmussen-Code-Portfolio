#include "Network.h"
#include <chrono>
#include <iostream>
#include <sstream>
int main()
{
	try
	{

		WSASession Session;
		UDPSocket Socket;
		char buffer[100];

		Socket.Bind(100);
		while (1)
		{
			sockaddr_in add = Socket.RecvFrom(buffer, sizeof(buffer));
			std::string input(buffer);
			int ClientTime;
			//
			std::stringstream ss;

			/* Storing the whole string into string streamb */ 
			
			ss << input;

			/* Running loop till the end of the stream */
			std::string temp;
			auto found=0;
			while (!ss.eof()) {

				/* extracting word by word from stream */
				ss >> temp;

				/* Checking the given word is integer or not */
				if (std::stringstream(temp) >> found)
					std::cout << found << " ";
				
				/* To save from space at the end of string */
				ss >> ClientTime;
				temp = "";
				
			}
			auto timeProduced = std::chrono::duration_cast<std::chrono::milliseconds>(std::chrono::system_clock::now().time_since_epoch()).count();
			input +=" "+ std::to_string(timeProduced)+" ";
			auto timechanged = timeProduced - ClientTime;
			input += " " + std::to_string(timechanged) + " ";
			//std::reverse(std::begin(input), std::end(input));
			Socket.SendTo(add, input.c_str(), input.size());
		}
	}
	catch (std::system_error& e)
	{
		std::cout << e.what();
	}
}