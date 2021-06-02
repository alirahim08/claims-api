resource "aws_subnet" "public_1a" {
  vpc_id = aws_vpc.application_vpc.id
  cidr_block = "10.${var.vpc_cidr_ip_block}.4.0/24"
  map_public_ip_on_launch = "false"
  availability_zone = "us-east-1a"
  tags = {
    Name = "${var.resource_prefix}subnet-pub-1a"
  }
}

resource "aws_subnet" "public_1b" {
  vpc_id = aws_vpc.application_vpc.id
  cidr_block = "10.${var.vpc_cidr_ip_block}.5.0/24"
  map_public_ip_on_launch = "false"
  availability_zone = "us-east-1b"
  tags = {
    Name = "${var.resource_prefix}subnet-pub-1b"
  }
}

resource "aws_subnet" "private_1a" {
  vpc_id = aws_vpc.application_vpc.id
  cidr_block = "10.${var.vpc_cidr_ip_block}.1.0/24"
  map_public_ip_on_launch = "false"
  availability_zone = "us-east-1a"
  tags = {
    Name = "${var.resource_prefix}subnet-pvt-1a"
  }
}

resource "aws_subnet" "private_1b" {
  vpc_id = aws_vpc.application_vpc.id
  cidr_block = "10.${var.vpc_cidr_ip_block}.2.0/24"
  map_public_ip_on_launch = "false"
  availability_zone = "us-east-1b"
  tags = {
    Name = "${var.resource_prefix}subnet-pvt-1b"
  }
}

resource "aws_subnet" "private_web_1a" {
  vpc_id = "${aws_vpc.application_vpc.id}"
  cidr_block = "10.${var.vpc_cidr_ip_block}.7.0/24"
  map_public_ip_on_launch = "false"
  availability_zone = "us-east-1a"

  tags = {
    Name = "${var.resource_prefix}subnet-pvt-web-1a"
  }
}

resource "aws_subnet" "private_web_1b" {
  vpc_id = "${aws_vpc.application_vpc.id}"
  cidr_block = "10.${var.vpc_cidr_ip_block}.8.0/24"
  map_public_ip_on_launch = "false"
  availability_zone = "us-east-1b"
  tags = {
    Name = "${var.resource_prefix}subnet-pvt-web-1b"
  }
}