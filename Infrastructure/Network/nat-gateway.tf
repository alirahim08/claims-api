resource "aws_nat_gateway" "nat_gateway_2a" {
  allocation_id = aws_eip.eip_2a.id
  subnet_id = aws_subnet.private_web_2a.id

  depends_on = [aws_internet_gateway.main_internet_gateway, aws_subnet.private_2a]
  tags = {
    Name = "${var.resource_prefix}sub-pub-2a-nat"
  }
}

resource "aws_nat_gateway" "nat_gateway_2b" {
  allocation_id = aws_eip.eip_2a.id
  subnet_id = aws_subnet.private_web_2a.id

  depends_on = [aws_internet_gateway.main_internet_gateway,aws_subnet.private_2b]
  tags = {
    Name = "${var.resource_prefix}sub-pub-2b-nat"
  }
}