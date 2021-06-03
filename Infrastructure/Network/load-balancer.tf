resource "aws_lb" "api_load_balancer" {
  name               = "${var.resource_prefix}-api-loadbalancer"
  internal           = false
  load_balancer_type = "application"
  security_groups    = [aws_security_group.api_load_balancer_sg.id]
  subnets            = [aws_subnet.public_1a.id,
                        aws_subnet.public_1b.id]   

  enable_deletion_protection = true

  access_logs {
    bucket  = aws_s3_bucket.api_lb_logs.bucket
    enabled = true
  }

  tags = local.tags
}