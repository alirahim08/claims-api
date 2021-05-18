resource "aws_subnet" "public_2a" {
  vpc_id = aws_vpc.application_vpc.id
  cidr_block = "10.1.4.0/24"
  map_public_ip_on_launch = "false"
  availability_zone = "us-east-2a"
  tags = {
    Name = "${var.resource_prefix}subnet-pub-2a"
  }
}

resource "aws_subnet" "public_2b" {
  vpc_id = aws_vpc.application_vpc.id
  cidr_block = "10.1.5.0/24"
  map_public_ip_on_launch = "false"
  availability_zone = "us-east-2b"
  tags = {
    Name = "${var.resource_prefix}subnet-pub-2b"
  }
}

resource "aws_subnet" "private_2a" {
  vpc_id = aws_vpc.application_vpc.id
  cidr_block = "10.1.1.0/24"
  map_public_ip_on_launch = "false"
  availability_zone = "us-east-2a"
  tags = {
    Name = "${var.resource_prefix}subnet-pvt-2a"
  }
}

resource "aws_subnet" "private_2b" {
  vpc_id = aws_vpc.application_vpc.id
  cidr_block = "10.1.2.0/24"
  map_public_ip_on_launch = "false"
  availability_zone = "us-east-2b"
  tags = {
    Name = "${var.resource_prefix}subnet-pvt-2b"
  }
}

resource "aws_subnet" "private_web_2a" {
  vpc_id = "${aws_vpc.application_vpc.id}"
  cidr_block = "10.1.7.0/24"
  map_public_ip_on_launch = "false"
  availability_zone = "us-east-2a"

  tags = {
    Name = "${var.resource_prefix}subnet-pvt-web-2a"
  }
}

resource "aws_subnet" "private_web_2b" {
  vpc_id = "${aws_vpc.application_vpc.id}"
  cidr_block = "10.1.8.0/24"
  map_public_ip_on_launch = "false"
  availability_zone = "us-east-2b"
  tags = {
    Name = "${var.resource_prefix}subnet-pvt-web-2b"
  }
}