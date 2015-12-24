#pragma once
#include <string>
using namespace std;

class Trial
{
protected:
	char *subject;
	char *name;
	int score;
public:
	Trial();
	Trial(Trial&);
	Trial(char*, char*, int);
	~Trial();
	void SetSubject(char*);
	void SetScore(int);
	void SetName(char*);
	char *GetSubject();
	char *GetName();
	int GetScore();
	int GainScore(int);
};

class State
{
protected:
	char *name;
	int population;
	double area;
public:
	State();
	State(char*, int, double);
	State(State &);
	~State();
	void SetName(char*);
	void SetPopulation(int);
	void SetArea(double);
	char* GetName();
	int GetPopulation();
	double GetArea();
};



class Test : public Trial
{
protected:
	int score;
	static int maxScore;
public:
	Test();
	Test(Test&);
	Test(string, int);
	~Test();
	double GetRating();
	void GainScore(int);
};

class Exam : public Trial
{
protected:
	int mark;
	bool isPassed;
public:
	Exam();
	Exam(Exam&);
	Exam(string);
	~Exam();
	int GetMark();
	void SetMark(int);
	void Passed();
	bool IsPassed();
};

class FinalExam : public Exam
{
private:
	bool isAccessed;
	int finalMark;
public:
	FinalExam();
	FinalExam(FinalExam&);
	FinalExam(string);
	~FinalExam();
	bool IsAccessed();
	void GainAccessed();
	void SetFinalMark(int);
};