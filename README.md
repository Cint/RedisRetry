# RedisRetry
[![Build status](https://ci.appveyor.com/api/projects/status/bkemtm1mb0muvc1o/branch/master?svg=true)](https://ci.appveyor.com/project/Cint/redisretry)

A simple retry wrapper for [StackExchange.Redis](https://github.com/StackExchange/StackExchange.Redis)

## Features

RedisRetry is a library that you can add to your project that will extend your `IDatabase` interface.

It provides retry functionality (using [Polly](https://github.com/App-vNext/Polly])) for common Redis commands.
