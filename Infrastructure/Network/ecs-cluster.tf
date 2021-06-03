resource "aws_ecs_cluster" "ecs_cluster" {
  name = "${var.resource_prefix}-ecs-cluster"
}

resource "aws_autoscaling_group" "ecs_auto_scaling_group" {
  name                 = "${var.resource_prefix}-ecs-auto=scaling-group"
  vpc_zone_identifier  = [aws_subnet.private_web_1a.id,
                          aws_subnet.private_web_1b.id]
  launch_configuration = aws_launch_configuration.ecs_launch_config.name

  desired_capacity = 3
  min_size         = 3
  max_size         = 3
}

resource "aws_launch_configuration" "ecs_launch_config" {
  image_id = "${var.resource_prefix}-ecs-launch-config"
  instance_type = "t3.medium"
  security_groups = [aws_security_group.ecs_cluster_sg.id]
}