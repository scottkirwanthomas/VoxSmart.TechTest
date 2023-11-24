# Doubts, Questions & Assumptions 
My solution works on the premise of a known list of words to try and find within each market item.  This list could be large and come from multiple sources, in the short term I've hard coded a static list as a representation of what could used.  The sources of data to look for could be loaded from external sources such as a database or an api as an alternative.

I would expect this library to be used as part of a wider solution either within an api or hosted service and as such no host has been configured.

Without understanding the non functionals it is hard to know if this solution is fit for purpose as there is no indication of volume,  frequency or performance expectations.

The logger is representative and I assume there would be an existing process for logging that would have to be adhered to.

Likewise there is no consideration for security as to who can call the method etc.

I feel the matching process could be improved.  There is no indication if we should look within just the title, description, content or all of them and as such the strategies should be altered, enhanced accordingly based on further requirements.

More startegies could be created depending on th e item sto search for.  Each strategy has the abaility to utilise a different matching pattern, this could be changed to use a regex or even an external service.

Again without understanding the non functionals the scope for scaling this approach is large as you could queue each market item and have a startegy listen to the queue so each startegy could run in isolation as a separate service.  As I say withinout understaning the use cases in full coupled with the non functionals an overall solution can only be guessed at.
