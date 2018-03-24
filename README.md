# RedisRetry
[![Build status](https://ci.appveyor.com/api/projects/status/bkemtm1mb0muvc1o/branch/master?svg=true)](https://ci.appveyor.com/project/Cint/redisretry/branch/master)

A simple retry wrapper for [StackExchange.Redis](https://github.com/StackExchange/StackExchange.Redis)

## Features

RedisRetry is a library that you can add to your project that will extend your `IDatabase` interface.

It provides retry functionality (using [Polly](https://github.com/App-vNext/Polly)) for common Redis commands.

####When is it safe to retry?
Each application needs to decide what operations can be retried and which cannot. See https://gist.github.com/JonCole/925630df72be1351b21440625ff2671f#when-is-it-safe-to-retry for a more in-depth answer.

For most applications idempotent operations _should_ be safe to retry. For example `HashGetAsync` or `KeyExpireAsync` are idempotent while `HashIncrementAsync` is not.