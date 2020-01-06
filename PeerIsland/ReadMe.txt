1-Solution Consists Of Two Controllers
	One For Problem 1
	Employee Controller v2 is for Problem 2.
2-Process To Run The Solution
	a-Go to appSettings.Json File And Update key "XMLFilePath" to the XML file Location. Recommendation to put the xml file in "D" drive to avoid permission issues
	b- XML Schema is followed as per the question
	c- Build and Run the Application Follow Swagger UI to validate
3- The Solution Uses 
	a-ASP .Net Core 2.2 . This needs to be installed Prior running application
	b- All the repositiry and Db Context has been created Generic To make this code extendible.
	c-This Uses Out of the box ASP .Net Core Dependency injenction.
	d-The Dlls hass been moved to a folder to simulate 3rd party softwares  for problem 2.


