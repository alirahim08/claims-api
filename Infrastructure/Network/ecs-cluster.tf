resource "aws_ecs_cluster" "ecs_cluster" {
  name = "${var.resource_prefix}-ecs-cluster"
  
  setting {
    name  = "containerInsights"
    value = "enabled"
  }
}

//resource "aws_ecs_capacity_provider" "ecs_capacity_provider" {
//  name = "${var.resource_prefix}-ecs-capacity-provider"
//  auto_scaling_group_provider {
//    auto_scaling_group_arn = aws_autoscaling_group.ecs_auto_scaling_group.arn
//  }
//}

resource "aws_autoscaling_group" "ecs_auto_scaling_group" {
  name                 = "${var.resource_prefix}-ecs-auto=scaling-group"
  vpc_zone_identifier  = [aws_subnet.private_web_1a.id,
                          aws_subnet.private_web_1b.id]
  launch_configuration = aws_launch_configuration.ecs_launch_config.name

  desired_capacity = 3
  min_size         = 3
  max_size         = 3
  health_check_grace_period = 300
  health_check_type = "EC2"
}

data "aws_ami" "amazon_linux_ami" {
  most_recent = true
  owners      = ["amazon"]
  filter {
    name   = "name"
    values = ["amzn-ami-*-x86_64-gp2"]
  }
  filter {
    name   = "virtualization-type"
    values = ["hvm"]
  }
}

resource "aws_launch_configuration" "ecs_launch_config" {
  image_id = data.aws_ami.amazon_linux_ami.id
  instance_type = "t3.medium"
  security_groups = [aws_security_group.ecs_cluster_sg.id]
}

resource "aws_ecr_repository" "carriers_repository" {
  name = "carriers-api"
}

data "template_file" "carrier_task_definition_template" {
  template = file("carrier_api_task_definition.json.tpl")
}