# public route table to map public subnets and db subnets
resource "aws_route_table" "subnet_public_route_table" {
  vpc_id = aws_vpc.application_vpc.id

  route {
    cidr_block = "0.0.0.0/0"
    gateway_id = aws_internet_gateway.main_internet_gateway.id
  }

  route {
    cidr_block = "0.0.0.0/0"
    gateway_id = aws_internet_gateway.main_internet_gateway.id
  }

  route {
    cidr_block = "0.0.0.0/0"
    gateway_id = aws_internet_gateway.main_internet_gateway.id
  }

  route {
    cidr_block = "0.0.0.0/0"
    gateway_id = aws_internet_gateway.main_internet_gateway.id
  }

  tags = {
    Name = "${var.resource_prefix}subnet-public-rt"
  }
}

resource "aws_route_table" "subnet_pvt_2a_route_table" {
  vpc_id = aws_vpc.application_vpc.id

  route {
    cidr_block = "0.0.0.0/0"
    gateway_id = aws_nat_gateway.nat_gateway_2a.id
  }

  tags = {
    Name = "${var.resource_prefix}subnet-pvt-web-2a-rt"
  }
}

resource "aws_route_table" "subnet_pvt_2b_route_table" {
  vpc_id = aws_vpc.application_vpc.id

  route {
    cidr_block = "0.0.0.0/0"
    gateway_id = aws_nat_gateway.nat_gateway_2b.id
  }

  tags = {
    Name = "${var.resource_prefix}subnet-pvt-web-2b-rt"
  }
}