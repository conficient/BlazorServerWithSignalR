# BlazorServerWithSignalR
A server-side "SignalR" example, that doesn't use SignalR!

Eh? Yes that's right - this is a Chat sample that does not use SignalR. Except it _does_ because Blazor server-side uses SignalR behind the scenes.

The app has a service called `TalkService` that has a list of the last 10 messages, an event raised when a new message is added, 
and a method to send a message.

It's registered as a singleton instance, so every consumer has the same service. Clients register for new messages via the event. 

They can also send their own by calling `SendAsync` - everyone who is listening gets the update.

It also has a `BackgroundService` called `TimerService` - this generates a message with the time every five seconds. 
