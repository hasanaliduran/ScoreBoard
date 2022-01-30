# ScoreBoard

The case implementation basically consists of two different projects. The first one is the library implementation and the other one is the test project. 

The library implementation basically consists of 3 classes: Team, Match and ScoreBoard. In addition, IScoreBoard, where the library's methods are served, is implemented in the ScoreBoard class. In order to make this class more efficient, matches are stored in two different ways as dictionary and sorted set. Sorted set is for eliminating unnecessary sorting calls in each list access, and dictionary is for accessing matches with O(1) complexity.
