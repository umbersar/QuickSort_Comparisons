
# Python program for implementation of Quicksort Sort

# This function takes last element as pivot, places
# the pivot element at its correct position in sorted
# array, and places all smaller (smaller than pivot)
# to left of pivot and all greater elements to right
# of pivot
from random import seed
from random import sample
from memory_profiler import profile
import psutil
import os

def partition(arr, low, high):
	i = (low-1)		 # index of smaller element
	pivot = arr[high]	 # pivot

	for j in range(low, high):

		# If current element is smaller than or
		# equal to pivot
		if arr[j] <= pivot:

			# increment index of smaller element
			i = i+1
			arr[i], arr[j] = arr[j], arr[i]

	arr[i+1], arr[high] = arr[high], arr[i+1]
	return (i+1)

# The main function that implements QuickSort
# arr[] --> Array to be sorted,
# low --> Starting index,
# high --> Ending index

# Function to do Quick sort


def quickSort(arr, low, high):
	if len(arr) == 1:
		return arr
	if low < high:

		# pi is partitioning index, arr[p] is now
		# at right place
		pi = partition(arr, low, high)

		# Separately sort elements before
		# partition and after partition
		quickSort(arr, low, pi-1)
		quickSort(arr, pi+1, high)


#@profile
def wrapper_quickSort(arr, low, high):
	quickSort(arr, low, high)

# Driver code to test above
# arr = [10, 7, 8, 9, 1, 5]
process = psutil.Process(os.getpid())
process.memory_info().wset

sequence = [i for i in range(50000000)]
arr = sample(sequence, 5000000)
n = len(arr)
wrapper_quickSort(arr, 0, n-1)
#memory_usage(quickSort(arr, 0, n-1))

process = psutil.Process(os.getpid())
process.memory_info().wset

print("Sorted array is:")
# for i in range(n):
# 	print("%d" % arr[i]),

# This code is contributed by Mohit Kumra
#This code in improved by https://github.com/anushkrishnav
