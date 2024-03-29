#include "user.h"

int Test::maxPoint = 100;
int Test::minPoint = 60;

Test::Test()
{
	this->point = 0;
	this->subject = "undefinded";
}

Test::Test(Test &obj)
{
	this->point = obj.GetPoints();
	this->subject = new char[100];
	strcpy(this->subject, obj.GetSubject());
}

Test::Test(char * _subject, int _point)
{
	this->subject = _subject;
	this->point = _point;
}

Test::~Test()
{
	delete this->subject;
}

void Test::GainPoints(int value)
{
	this->point += value;
}

const int Test::GetPoints()
{
	return this->point;
}

const char * Test::GetSubject()
{
	return this->subject;
}

const bool Test::IsPassed()
{
	return (this->GetPoints()) >= (Test::minPoint);
}

const double Test::GetRating()
{
	return (this->GetPoints())/(double)(Test::maxPoint);
}

void Test::Set()
{
	this->subject = Menu::Input::String("Enter subject name");
	this->point = Menu::Input::Number("Enter gain points (max = 100)");
}

bool Test::operator==(Test obj)
{
	bool result = strcmp(this->GetSubject(), obj.GetSubject());
	result &= (this->GetPoints() == obj.GetPoints());
	return result;
}

std::ostream & operator<<(ostream &stream, Test &obj)
{
	stream << "[ Test on " << obj.GetSubject() << " : "
		<< obj.GetPoints() << " out of " << Test::maxPoint << ", "
		<< " minimum: " << Test::minPoint << " "
		<< "(Rating: " << obj.GetRating() << ")]";
	return stream;
}