using Godot;

namespace GetOn.scenes.Programming {
    
    public class Checklist : AspectRatioContainer {
        private SharedNode _sharedNode;
        
        private CheckBox _jumping;
        private CheckBox _jumpingKey;
        private CheckBox _moving;
        private CheckBox _movingKey;
        private CheckBox _movingSpeed;
        private CheckBox _easyFlag;
        private CheckBox _hardFlag;
        private Button _submit;
        private CountdownTimer _timer;

        private bool hasSpacebar = false;
        private bool hasD = false;

        public override void _Ready() {
            _sharedNode = GetNode<SharedNode>("/root/SharedNode");
            _jumping = GetNode<CheckBox>("Items/Jumping");
            _jumpingKey = GetNode<CheckBox>("Items/JumpingKey");
            _moving = GetNode<CheckBox>("Items/Moving");
            _movingKey = GetNode<CheckBox>("Items/MovingKey");
            _movingSpeed = GetNode<CheckBox>("Items/MovingSpeed");
            _easyFlag = GetNode<CheckBox>("Items/EasyFlag");
            _hardFlag = GetNode<CheckBox>("Items/HardFlag");
            _submit = GetNode<Button>("Items/SubmitButton");
            _submit.Connect("pressed", this, nameof(Submit));
            _timer = GetNode<CountdownTimer>("/root/Programming/Game/Timer");
        }

        public void OnJump() {
            _jumping.Pressed = true;
            if (hasSpacebar) {
                _jumpingKey.Pressed = true;
            }
        }

        public void OnSpaceBar(bool spaceState) {
            hasSpacebar = spaceState;
        }

        public void OnDPressed(bool dState) {
            hasD = dState;
        }

        public void OnMove() {
            _moving.Pressed = true;
            if (hasD) {
                _movingKey.Pressed = true;
            }
        }

        public void MoveSpeed(float speed) {
            if (speed > 4) {
                _movingSpeed.Pressed = true;
            }
        }

        public void EasyFlag() {
            _easyFlag.Pressed = true;
        }
        
        public void HardFlag() {
            _hardFlag.Pressed = true;
        }

        public void OnProcess() {
            hasSpacebar = false;
            hasD = false;
        }

        public void Reset() {
            _jumping.Pressed = false;
            _jumpingKey.Pressed = false;
            _moving.Pressed = false;
            _movingKey.Pressed = false;
            _movingSpeed.Pressed = false;
            _easyFlag.Pressed = false;
            _hardFlag.Pressed = false;
        }
        
        public void TimeOut() {
            Submit();
        }

        private void Submit() {
            var points = 0;
            if (_jumping.Pressed) {
                points += 5;
            }
            if (_jumpingKey.Pressed) {
                points += 15;
            }
            if (_moving.Pressed) {
                points += 5;
            }
            if (_movingKey.Pressed) {
                points += 25;
            }
            if (_movingSpeed.Pressed) {
                points += 5;
            }
            if (_easyFlag.Pressed) {
                points += 10;
            }
            if (_hardFlag.Pressed) {
                points += 40;
            }
            _sharedNode.programmingPoints = points;
            _sharedNode.programmingTime = _timer.CurrentTime;
            _sharedNode.SwitchScene("res://scenes/EndScreen/EndScreen.tscn");
        }
    }
}