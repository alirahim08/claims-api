resource "aws_security_group" "api_load_balancer_sg" {
  name = "${var.resource_prefix}-api-loadbalancer-sg"
  vpc_id = aws_vpc.application_vpc.id
  ingress {
    from_port = 80
    protocol = "tcp"
    to_port = 80
    cidr_blocks      = ["0.0.0.0/0"]
    ipv6_cidr_blocks = ["::/0"]
  }
  
  ingress {
    from_port = 443
    protocol = "tcp"
    to_port = 443
    cidr_blocks      = ["0.0.0.0/0"]
    ipv6_cidr_blocks = ["::/0"]
  }
  
  egress {
    from_port = 0
    protocol = "-1"
    to_port = 0
    cidr_blocks      = ["0.0.0.0/0"]
    ipv6_cidr_blocks = ["::/0"]
  }
}

resource "aws_security_group" "ecs_cluster_sg" {
  name = "${var.resource_prefix}-ecs-cluster-sg"
  vpc_id = aws_vpc.application_vpc.id
  ingress {
    from_port = 0
    protocol = "tcp"
    to_port = 65535
    security_groups = [aws_security_group.api_load_balancer_sg.id]
  }

  egress {
    from_port = 0
    protocol = "-1"
    to_port = 0
    cidr_blocks      = ["0.0.0.0/0"]
    ipv6_cidr_blocks = ["::/0"]
  }
}