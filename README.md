# Speed Test Ping Service
A Windows Service that pings speedtest.net and fast.com on an interval

The idea is that an Internet Service Provider might unthrottle a user's internet 
connection right after that user visits a speed test website. This Windows service
aims to exploit this unthrottling, should it actually exist, to maximize connection
performance at all times.  

Inspired by [this Hacker News thread](https://news.ycombinator.com/item?id=12257176).

Note: The service currently only pings the webservers. It might be more effective to do an actual web request at some point.

##Why fast.com?
Fast.com uses Netflix's actual CDN and requests actual video files over HTTP.  
This prevents ISPs from whitelisting fast.com without also whitelisting Netflix itself. 
See [this article](http://techblog.netflix.com/2016/08/building-fastcom.html) for more.
