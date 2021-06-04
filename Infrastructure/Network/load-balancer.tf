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

resource "aws_lb_listener" "front_end" {
  load_balancer_arn = aws_lb.api_load_balancer.arn
  port              = "443"
  protocol          = "HTTPS"
  ssl_policy        = "ELBSecurityPolicy-2016-08"
  certificate_arn   = data.aws_acm_certificate.issued.arn
  
  default_action {
    type             = "forward"
    target_group_arn = aws_lb_target_group.api_target_group.arn
  }
}

resource "aws_lb_target_group" "api_target_group" {
  name     = "${var.resource_prefix}-api-lb-target-group"
  port     = 80
  protocol = "HTTP"
  vpc_id   = aws_vpc.application_vpc.id
  tags = local.tags
}
