# Drive map serivce

This service will map network shares to drive letters.  This use useful
if you want a service to save files to a network share but the service
does not support UNC paths.

# Setup

Edit the setting DrivesToMap to that each entry is the drive letter
(without the colon) and the network share path (without a trailing slash).

# Mapping before other services start

See [this Microsoft KB article](http://support.microsoft.com/kb/193888).