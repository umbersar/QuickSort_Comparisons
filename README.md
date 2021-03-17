# QuickSort_Comparisons
Comparison of quicksort implementations in C#, C++, Python and F#

## Timings
f# seq: 5000000 numbers
run 1: 1.02 minutes (60.7 secs) max memory 2.2 gb
run 3: time taken 34.5357793 seconds or time taken 0.5755963217 minutes

f# parallel depth 0: 5000000 numbers
run 1:time taken 33.3760227 seconds ortime taken 0.556267045 minutes

f# parallel depth 1: 5000000 numbers
run 1:time taken 38.9097901 seconds or time taken 0.6484965017 minutes

c# seq: 5000000 numbers
run 1: time taken 4.5876233 seconds or time taken 0.07646038833333334 minutes max memory 300 mb
run 1: time taken 4.5876233 seconds or time taken 0.07646038833333334 minutes max memory 313 mb

c# seq: 50000000 numbers using the in-efficient method of traversing list twice and creating 2 sub lists for each recursion level
run 1: time taken 48.2457183 seconds or time taken 0.804095305 minutes max memory 2.2 gb

c++ seq: 50000000 numbers. this was debug version and hanged for some reason. Release was very fast as shown below
run 1: waited for 3.5 minutes before cancelling max memory 195 mb

c++ seq: 50000000 numbers. release
run 1: time taken 6 seconds max memory 195 mb

c# seq: 50000000 numbers using inplace sort. release
run 1: time taken 5.5775463 seconds max memory 405 mb

c# seq: 50000000 numbers using inplace sort. debug
run 1: time taken 16.3402229 seconds max memory 405 mb

c# seq: 70000000 numbers using inplace sort. release
run 1: time taken 7.8637163 seconds max memory 559 mb

c++ seq: 70000000 numbers. release
run 1: time taken 7.8 seconds max memory 269 mb


python seq: 5000000 numbers (almost 3 times slower than f# even when this is a in-place sort). Do not know the memory usage
run 1: 2 minutes 50 secs (170 secs) max memory 2.2 gb

