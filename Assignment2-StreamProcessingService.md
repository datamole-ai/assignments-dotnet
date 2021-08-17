# Assignment 2 - Service processing large data streams

* Check projects [StreamProcessingService](sln/StreamProcessingService) and [StreamProcessingService.Tests](sln/StreamProcessingService.Tests).
* Implement interface [IStreamService](sln/StreamProcessingService/IStreamService.cs) and update [StreamServiceFactory](sln/StreamProcessingService/StreamServiceFactory.cs) accordingly.
* Associated unit tests must be passed.
* Add other appropriate unit tests.
* It is not allowed to use any NuGet dependencies except those already referenced in the two projects.
* Keep in mind that tests can only reveal errors, not prove their absence.

## Method 1

```csharp
double CalculateAverage(IEnumerable<IList<double>> dataStreams);
```

This method should calculate the arithmetic average (mean) of all doubles contained in the input collections.

Implementation of the method should take into an account following assumptions about the input data and the environment:

* The outer collection (IEnumerable) can contain up to 256 inner lists and is does not do any I/O in the background.
* Each inner list contain apprx. 10^5 items.
* The machine running this code has enough RAM to keep items of all inner lists at once in the memory.
* The machine running this code has multiple cores (threads).
* Overall, the computation performed by this method is considered to be CPU-bound.

## Method 2

```csharp
Task<double> CalculateAverageAsync(IEnumerable<Stream> dataStreams);
```

This method should calculate the arithmetic average (mean) of all doubles contained in the input collection of streams.

Each input stream contains UTF-8 encoded text lines. Each line contain zero, one or more doubles separated with semicolons. Some lines can be empty. Some values are not valid string representation of a double. Such values should be ignored. Any white space should be ignored.

See following example. From this input lines:

```
1.3;0.4;513

1.5
2;4; 5; 5
6 ;ppp;8.1
```

, these numbers should be extracted:

```
[1.3, 0.4, 513, 1.5, 2, 4, 5, 5, 6, 8.1]
```

Implementation of the method should take into an account following assumptions about the input data and the environment:

* The outer collection (IEnumerable) can contain up to 512 inner streams.
* The input streams can be huge. The machine running this code has NOT enough RAM to keep not even one of these streams in the memory.
* However, individual lines are relatively short. Multiple of them can fit into the memory at once.
* The input streams are expected to be waiting for I/O operations frequently (e.g. network or file stream).
* The machine running this code has multiple cores (threads).
* Overall, the computation performed by this method is considered to be I/O-bound.

## Method 3

```csharp
double CalculateAverage<T>(IList<T> data, int parallelismDegree, Func<T, double> valueExtractor);
```

This method should calculate the arithmetic average (mean) of all doubles extracted from the input collection. Each double must be first extracted from single a object of type T using user-provided extractor (it can be e.g. some regression model).

Implementation of the method should take into an account following assumptions about the input data and the environment:


* The duration of extraction of the double can extremely vary for various items of the input collection. E.g. for some input objects it can take approx. 200ms and approx. 200s for some other input objects.
* The machine running this code has enough RAM to keep all the input data in memory.
* The machine running this code has exactly `parallelismDegree` cores (threads).
* Overall, the computation performed by this method is considered to be CPU-bound.

## Method 4


```csharp
IEnumerable<double> JoinAndSort(Stream stream1, Stream stream2);
```

This method should take two input collections of doubles (encoded in streams) and return single collection of doubles in ascending order. The input collections are already ordered in the ascending order.

Each input stream contains UTF-8 encoded text lines. Each line contain zero or one double. Some lines can be empty. Some values are not valid string representation of a double. Such values should be ignored. Any white space should be ignored.

See following example. From this input lines:

```
1.3

 1.5
pp p p
6
```

, these numbers should be extracted:

```
[1.3, 1.5, 6]
```

* The input streams can be huge. The machine running this code has NOT enough RAM to keep not even one of these streams in the memory.
* However, individual lines are relatively short. Multiple of them can fit into the memory at once.
* Overall, the computation performed by this method is considered to be I/O-bound.