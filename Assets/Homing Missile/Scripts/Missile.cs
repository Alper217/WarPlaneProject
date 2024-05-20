using UnityEngine;

namespace Tarodev
{
    public class Missile : MonoBehaviour
    {
        [Header("REFERENCES")]
        [SerializeField] private GameObject[] missiles;
        [SerializeField] private Target _target;
        [SerializeField] private GameObject _explosionPrefab;

        [Header("MOVEMENT")]
        [SerializeField] private float _speed = 15;
        [SerializeField] private float _rotateSpeed = 95;

        [Header("PREDICTION")]
        [SerializeField] private float _maxDistancePredict = 100;
        [SerializeField] private float _minDistancePredict = 5;
        [SerializeField] private float _maxTimePrediction = 5;
        private Vector3 _standardPrediction, _deviatedPrediction;

        [Header("DEVIATION")]
        [SerializeField] private float _deviationAmount = 50;
        [SerializeField] private float _deviationSpeed = 2;

        private void FixedUpdate()
        {
            foreach (var missile in missiles)
            {
                // Objeyi ileriye doðru hareket ettirme
                missile.transform.position += missile.transform.forward * _speed * Time.deltaTime;

                var leadTimePercentage = Mathf.InverseLerp(_minDistancePredict, _maxDistancePredict, Vector3.Distance(missile.transform.position, _target.transform.position));

                PredictMovement(leadTimePercentage);

                AddDeviation(leadTimePercentage);

                RotateRocket(missile);
            }
        }

        private void PredictMovement(float leadTimePercentage)
        {
            var predictionTime = Mathf.Lerp(0, _maxTimePrediction, leadTimePercentage);

            _standardPrediction = _target.transform.position + _target.Rb.velocity * predictionTime;
        }

        private void AddDeviation(float leadTimePercentage)
        {
            var deviation = new Vector3(Mathf.Cos(Time.time * _deviationSpeed), 0, 0);

            var predictionOffset = deviation * _deviationAmount * leadTimePercentage;

            _deviatedPrediction = _standardPrediction + predictionOffset;
        }

        private void RotateRocket(GameObject missile)
        {
            var heading = _deviatedPrediction - missile.transform.position;

            var rotation = Quaternion.LookRotation(heading);
            missile.transform.rotation = Quaternion.RotateTowards(missile.transform.rotation, rotation, _rotateSpeed * Time.deltaTime);
        }

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (_explosionPrefab) Instantiate(_explosionPrefab, missiles[0].transform.position, Quaternion.identity);
        //    if (other.transform.TryGetComponent<IExplode>(out var ex)) ex.Explode();

        //    foreach (var missile in missiles)
        //    {
        //        Destroy(missile.gameObject);
        //    }
        //}

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(missiles[0].transform.position, _standardPrediction);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(_standardPrediction, _deviatedPrediction);
        }
    }
}
