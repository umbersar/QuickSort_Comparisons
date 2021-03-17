// Learn more about F# at http://fsharp.org

open System
open System.Threading.Tasks

module myMod =
    let genRandomNums count =
        let rnd = System.Random()
        List.init count (fun _ -> rnd.Next(System.Int32.MaxValue))
    
    let genRandomNums_arr count =
        let rnd = System.Random()
        Array.init count (fun _ -> rnd.Next(System.Int32.MaxValue))
    
    let rec quicksortSequential aList =
        match aList with
        | [] -> []
        | firstElement :: restOfList ->
            let smaller, larger = List.partition (fun number -> number < firstElement) restOfList
            quicksortSequential smaller @ (firstElement :: quicksortSequential larger)
            //let left = Task.Run(fun () -> quicksortSequential smaller)
            //let right = Task.Run(fun () -> quicksortSequential larger)
            //left.Result @ (firstElement :: right.Result)
    
    let rec quicksortParallel depth aList =
        match aList with
        | [] -> []
        | firstElement :: restOfList ->
            let smaller, larger =
                List.partition (fun number -> number < firstElement) restOfList
            if depth < 0 then
                let left  = quicksortParallel depth smaller
                let right = quicksortParallel depth larger
                left @ (firstElement :: right)
            else
                let left  = Task.Run(fun () -> quicksortParallel (depth-1) smaller)
                let right = Task.Run(fun () -> quicksortParallel (depth-1) larger)
                
                Task.WaitAll(left, right)

                left.Result @ (firstElement :: right.Result)

    let swap (aArray: int array) indexA indexB = 
        let temp = aArray.[indexA]
        Array.set aArray indexA (aArray.[indexB])
        Array.set aArray indexB (temp)

    let partition (aArray: int array) first last =
        let pivot = aArray.[last]
        let mutable wallindex = first;
        let mutable currentindex = first
        while currentindex < last do  
            if aArray.[currentindex] < pivot then
                swap aArray wallindex currentindex
                wallindex <- wallindex + 1

            currentindex <- currentindex + 1    

        swap aArray wallindex last
        wallindex

    let rec quicksortParallelInPlace (aArray: int array) first last depth =
        if ((last - first) >= 1) then
            let pivotposition = partition aArray first last
            if depth < 0 then
                quicksortParallelInPlace aArray first (pivotposition - 1) depth
                quicksortParallelInPlace aArray (pivotposition + 1) last depth
            else
                let left  = Task.Run(fun () -> quicksortParallelInPlace aArray first (pivotposition - 1) (depth-1))
                let right = Task.Run(fun () -> quicksortParallelInPlace aArray (pivotposition + 1) last (depth-1))
                Task.WaitAll(left, right)
                        

    let quickSortInPlace (aArray: int array) depth =
        quicksortParallelInPlace aArray 0 (aArray.Length - 1) depth

    //let sampleNumbers_arr = [|2; 1; 3; 0; 7; 4 |]
    let sampleNumbers_arr = genRandomNums_arr 50000000
    
    //printfn "un-sorted list %A" sampleNumbers_arr 

    let stopWatch1 = System.Diagnostics.Stopwatch.StartNew()
    //let sortedSnums = quicksortParallel -1 sampleNumbers //this runs the quicksort sequentially
    quickSortInPlace sampleNumbers_arr 4
    stopWatch1.Stop()

    //printfn "un-sorted list %A" sampleNumbers_arr

    printfn "time taken %A millseconds\n" stopWatch1.Elapsed.TotalMilliseconds
    printfn "time taken %A seconds\n" stopWatch1.Elapsed.TotalSeconds
    printfn "time taken %A minutes\n" stopWatch1.Elapsed.TotalMinutes
    printfn "time taken %A hours\n" stopWatch1.Elapsed.TotalHours        

    //let sampleNumbers = [ 2; 1; 3; 0; 7; 4 ]
    let mutable sampleNumbers = genRandomNums 5000000
    
    //printfn "un-sorted list %A" sampleNumbers
    //printfn "sorted list %A" (quicksortSequential sampleNumbers)

    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    //let sortedSnums = quicksortParallel -1 sampleNumbers //this runs the quicksort sequentially
    let sortedSnums = quicksortParallel -4 sampleNumbers
    stopWatch.Stop()

    //printfn "un-sorted list %A" sortedSnums

    printfn "time taken %A millseconds\n" stopWatch.Elapsed.TotalMilliseconds
    printfn "time taken %A seconds\n" stopWatch.Elapsed.TotalSeconds
    printfn "time taken %A minutes\n" stopWatch.Elapsed.TotalMinutes
    printfn "time taken %A hours\n" stopWatch.Elapsed.TotalHours

