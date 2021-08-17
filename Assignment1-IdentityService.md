# Assignment 1 - Implement simple identity service

The goal is to implement a simple identity service which keeps its state in the memory and is able to save/load its state to/from a file.

* Check projects [IdentityService](sln/IdentityService) and [IdentityService.Tests](sln/IdentityService.Tests).
* Implement interface [IIdentityService](sln/IdentityService/IIdentityService.cs) and update [IdentityServiceFactory](sln/IdentityService/IdentityServiceFactory.cs) accordingly.
* Associated unit tests must be passed.
* Add other appropriate unit tests.
* It is not allowed to use any NuGet dependencies except those already referenced in the two projects.
* Use JSON format and UTF-8 encoding.
* Keep in mind that tests can only reveal errors, not prove their absence.
* Keep in mind that the service manages and stores sensitive data.
* Keep the complexity at the minimum. Take into an account the assumptions below.
* User names are case insensitive. However, keep the original form including the letter casing when storing the user name in a file.
* Assumptions
    * The size of the internal state of the service (and its serialized form) is small enough to easily fit in the memory and is not expected to grow.
    * User names and their count are not confidential.
    * The file is protected from the manipulation by the unauthorized entities. Therefore, you do not need to deal with consistency issues of the file.
    * Feel free to discuss any other possible assumptions.
    * Document any other assumption made by your implementation.

## Bonus task 1 (basic cryptography skills required)

New assumption: The file used for persisting the state *might be leaked* to the unauthorized entities.

## Bonus task 2 (intermediate cryptography skills required)

New assumption: The user names are considered confidential.

## Bonus task 3 (intermediate cryptography skills required)

New assumption: The file used for persisting the state *might be writable* by the unauthorized entities. The consistency becomes a critical issue.