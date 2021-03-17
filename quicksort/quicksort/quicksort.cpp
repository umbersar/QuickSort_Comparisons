// quicksort.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include<vector>
#include <random>
#include<chrono>

//#include <taskflow.hpp>  

inline int partition(std::vector<int>& a, int start, int end)
{
	int pivot = a[end];
	//P-index indicates the pivot value index

	int P_index = start;
	int i, t; //t is temporary variable

	//Here we will check if array value is 
	//less than pivot
	//then we will place it at left side
	//by swapping 

	for (i = start; i < end; i++)
	{
		if (a[i] <= pivot)
		{
			t = a[i];
			a[i] = a[P_index];
			a[P_index] = t;
			P_index++;
		}
	}
	//Now exchanging value of
	//pivot and P-index
	t = a[end];
	a[end] = a[P_index];
	a[P_index] = t;

	//at last returning the pivot value index
	return P_index;
}

void Quicksort(std::vector<int>& a, int start, int end)
{
	if (start < end)
	{
		int P_index = partition(a, start, end);
		Quicksort(a, start, P_index - 1);
		Quicksort(a, P_index + 1, end);
	}
}

int main()
{
	// First create an instance of an engine.
	std::random_device rnd_device;
	// Specify the engine and distribution.
	std::mt19937 mersenne_engine{ rnd_device() };  // Generates random integers
	std::uniform_int_distribution<int> dist{ 1, 500000000 };
	auto gen = [&dist, &mersenne_engine]() {
		return dist(mersenne_engine);
	};

	int n = 70000000;
	std::vector<int> a(n);
	generate(begin(a), end(a), gen);

	// Optional
	/*for (auto i : a) {
		std::cout << i << " ";
	}*/

	std::cout << "\n";
	auto t1 = std::chrono::high_resolution_clock::now();
	Quicksort(a, 0, n - 1);
	auto t2 = std::chrono::high_resolution_clock::now();
	auto duration = std::chrono::duration_cast<std::chrono::microseconds>(t2 - t1).count();

	std::cout << duration;
	//executor.run(taskflow).wait();

	//// Optional
	/*for (auto i : a) {
		std::cout << i << " ";
	}*/

	return 0;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
