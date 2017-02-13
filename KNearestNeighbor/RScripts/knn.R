gc<-read.csv("C:/work/MachineLearning/Data/train.csv")
set.seed(345)
trainSize<-10000
testSize<-5000
train.gc<-gc[1:trainSize,-1]
test.gc<-gc[(trainSize+1):(trainSize+testSize),-1] #not good, test slice comes after train slice
train.def<-gc$label[1:trainSize]
test.def<-gc$label[(trainSize+1):(trainSize+testSize)]

library(class)

knn.1=knn(train.gc,test.gc,train.def,k=1)
100*sum(knn.1==test.def)/testSize


table(knn.1,test.def)