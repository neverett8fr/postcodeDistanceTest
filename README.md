# postcodeDistanceTest
For some reason not too long ago, I was looking at postcodes. Apparently postcodes have a lot more information included in them than I first thought.
e.g. Area: GU, District: 34, Sector: 4, Unit: DA = GU34 4DA
I wondered if this information could be used to see what's near you. It's not perfect, but it works.
I used a GeoJSON file made from a website called "http://overpass-turbo.eu/"; it took a while but I got all the restaurants (that the program had) in a file in the UK.
It uses Regex to separate the postcode into its constituent parts, then rates each postcode on the amount of matching parts etc. It's very simple - but a fun experiment.

![image](https://user-images.githubusercontent.com/43852724/116799002-1a4a9a80-aaed-11eb-8fc2-f17955841860.png)


![postcode_map](https://user-images.githubusercontent.com/43852724/116798964-ac9e6e80-aaec-11eb-9e38-4eb3789144b7.png)


The actual compiled application runs and finds results in less than a second, the intepreted version run in the IDE takes about 10 seconds or so.
![image](https://user-images.githubusercontent.com/43852724/116799044-8200e580-aaed-11eb-96fa-f88459f4902f.png)
