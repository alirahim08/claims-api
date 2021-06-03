# public route table to map public subnets and db subnets
resource "aws_route_table" "subnet_public_route_table" {
  vpc_id = aws_vpc.application_vpc.id

  route {
    cidr_block = "0.0.0.0/0"
    gateway_id = aws_internet_gateway.main_internet_gateway.id
  }

  tags = {
    Name = "${var.resource_prefix}-subnet-public-rt"
  }
}

resource "aws_route_table_association" "public_1a_association" {
  subnet_id      = aws_subnet.public_1a.id
  route_table_id = aws_route_table.subnet_public_route_table.id
}

resource "aws_route_table_association" "public_1b_association" {
  subnet_id      = aws_subnet.public_1b.id
  route_table_id = aws_route_table.subnet_public_route_table.id
}

resource "aws_route_table_association" "private_1a_association" {
  subnet_id      = aws_subnet.private_1a.id
  route_table_id = aws_route_table.subnet_public_route_table.id
}

resource "aws_route_table_association" "private_1b_association" {
  subnet_id      = aws_subnet.private_1b.id
  route_table_id = aws_route_table.subnet_public_route_table.id
}

resource "aws_route_table" "subnet_pvt_1a_route_table" {
  vpc_id = aws_vpc.application_vpc.id

  route {
    cidr_block = "0.0.0.0/0"
    gateway_id = aws_nat_gateway.nat_gateway_1a.id
  }

  tags = {
    Name = "${var.resource_prefix}-subnet-pvt-web-1a-rt"
  }
}

resource "aws_route_table_association" "private__web_1a_association" {
  subnet_id      = aws_subnet.private_web_1a.id
  route_table_id = aws_route_table.subnet_pvt_1a_route_table.id
}


resource "aws_route_table" "subnet_pvt_1b_route_table" {
  vpc_id = aws_vpc.application_vpc.id

  route {
    cidr_block = "0.0.0.0/0"
    gateway_id = aws_nat_gateway.nat_gateway_1b.id
  }

  tags = {
    Name = "${var.resource_prefix}-subnet-pvt-web-1b-rt"
  }
}


resource "aws_route_table_association" "private__web_1b_association" {
  subnet_id      = aws_subnet.private_web_1b.id
  route_table_id = aws_route_table.subnet_pvt_1b_route_table.id
}
