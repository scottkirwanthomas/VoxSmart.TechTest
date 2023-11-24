# Doubts, Questions & Assumptions 
My solution works on the premise of a known list of words to try find within each market item.  This list could be large and come from multiple sources so in the short term I've hard coded a static list as a representation of what could be achieved.  These sources of data to look for could be loaded from external sources such as a database or an api as an alternative.

I would expect this library to be used as part of a wider solution either within an api or hosted service and as such no host has been configured.

Without understanding the non functionals it is hard to know if this solution is fit for purpose as there is no indication of volume,  frequency or performance expectations.

The logger is representative and I assume there would be an existing process for logging that would have to be adhered to.

Likewise there is no consideration for security as to who can call the method etc.

I feel the matching process could be improved.  There is no indication if we should look within just the title, description, content or all of them and as such the strategies should be altered, enhanced accordingly based on further requirements.