resource "aws_nat_gateway" "nat_gateway_1a" {
  allocation_id = aws_eip.eip_1a.id
  subnet_id = aws_subnet.private_web_1a.id

  depends_on = [aws_internet_gateway.main_internet_gateway, aws_subnet.private_1a]
  tags = {
    Name = "${var.resource_prefix}-sub-pub-1a-nat"
  }
}

resource "aws_nat_gateway" "nat_gateway_1b" {
  allocation_id = aws_eip.eip_1b.id
  subnet_id = aws_subnet.private_web_1a.id

  depends_on = [aws_internet_gateway.main_internet_gateway,aws_subnet.private_1b]
  tags = {
    Name = "${var.resource_prefix}-sub-pub-1b-nat"
  }
}