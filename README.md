MVC5Pipelines
=============

Throwing together an example of using pipelines with standard MVC action filters and a custom pipeline. 


The idea is that there is a pipeline to go through which takes care of all the boring stuff like


Validation 400
Does the resource exist 404

Then when you get to the controller you know that you have a valid resource to work with.

