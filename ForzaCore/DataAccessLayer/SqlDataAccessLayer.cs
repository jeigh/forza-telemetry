using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForzaCore.DataAccessLayer
{
    public class SqlDataAccessLayer : IDataAccessLayer
    {
        public string CurrentFileName { get; set; } = string.Empty;

        public void WriteHeader(StringBuilder sb)
        {
            return; // no files to touch
        }

        public void RecordData(DataPacket data)
        {
            try
            {
                using SqlConnection theConnection = new SqlConnection(ConnectionString);
                using SqlCommand theCommand = new SqlCommand(InsertStatement, theConnection);

                AddParametersFromDataPacket(theCommand.Parameters, data);

                theCommand.Connection.Open();
                theCommand.ExecuteNonQuery();
                theCommand.Connection.Close();
            }
            catch (Exception ex)
            {
                // put breakpoint here
                
                
               // throw;
            }
        }

        private void AddParametersFromDataPacket(SqlParameterCollection parameters, DataPacket data)
        {
            parameters.AddWithValue("@IsRaceOn", data.IsRaceOn);
            parameters.AddWithValue("@TimestampMS", Convert.ToInt64(data.TimestampMS));
            parameters.AddWithValue("@EngineMaxRpm", data.EngineMaxRpm);
            parameters.AddWithValue("@EngineIdleRpm", data.EngineIdleRpm);
            parameters.AddWithValue("@CurrentEngineRpm", data.CurrentEngineRpm);
            parameters.AddWithValue("@AccelerationX", data.AccelerationX);
            parameters.AddWithValue("@AccelerationY", data.AccelerationY);
            parameters.AddWithValue("@AccelerationZ", data.AccelerationZ);
            parameters.AddWithValue("@VelocityX", data.VelocityX);
            parameters.AddWithValue("@VelocityY", data.VelocityY);
            parameters.AddWithValue("@VelocityZ", data.VelocityZ);
            parameters.AddWithValue("@AngularVelocityX", data.AngularVelocityX);
            parameters.AddWithValue("@AngularVelocityY", data.AngularVelocityY);
            parameters.AddWithValue("@AngularVelocityZ", data.AngularVelocityZ);
            parameters.AddWithValue("@Yaw", data.Yaw);
            parameters.AddWithValue("@Pitch", data.Pitch);
            parameters.AddWithValue("@Roll", data.Roll);
            parameters.AddWithValue("@NormalizedSuspensionTravelFrontLeft", data.NormalizedSuspensionTravelFrontLeft);
            parameters.AddWithValue("@NormalizedSuspensionTravelFrontRight", data.NormalizedSuspensionTravelFrontRight);
            parameters.AddWithValue("@NormalizedSuspensionTravelRearLeft", data.NormalizedSuspensionTravelRearLeft);
            parameters.AddWithValue("@NormalizedSuspensionTravelRearRight", data.NormalizedSuspensionTravelRearRight);
            parameters.AddWithValue("@TireSlipRatioFrontLeft", data.TireSlipRatioFrontLeft);
            parameters.AddWithValue("@TireSlipRatioFrontRight", data.TireSlipRatioFrontRight);
            parameters.AddWithValue("@TireSlipRatioRearLeft", data.TireSlipRatioRearLeft);
            parameters.AddWithValue("@TireSlipRatioRearRight", data.TireSlipRatioRearRight);
            parameters.AddWithValue("@WheelRotationSpeedFrontLeft", data.WheelRotationSpeedFrontLeft);
            parameters.AddWithValue("@WheelRotationSpeedFrontRight", data.WheelRotationSpeedFrontRight);
            parameters.AddWithValue("@WheelRotationSpeedRearLeft", data.WheelRotationSpeedRearLeft);
            parameters.AddWithValue("@WheelRotationSpeedRearRight", data.WheelRotationSpeedRearRight);
            parameters.AddWithValue("@WheelOnRumbleStripFrontLeft", data.WheelOnRumbleStripFrontLeft);
            parameters.AddWithValue("@WheelOnRumbleStripFrontRight", data.WheelOnRumbleStripFrontRight);
            parameters.AddWithValue("@WheelOnRumbleStripRearLeft", data.WheelOnRumbleStripRearLeft);
            parameters.AddWithValue("@WheelOnRumbleStripRearRight", data.WheelOnRumbleStripRearRight);
            parameters.AddWithValue("@WheelInPuddleDepthFrontLeft", data.WheelInPuddleDepthFrontLeft);
            parameters.AddWithValue("@WheelInPuddleDepthFrontRight", data.WheelInPuddleDepthFrontRight);
            parameters.AddWithValue("@WheelInPuddleDepthRearLeft", data.WheelInPuddleDepthRearLeft);
            parameters.AddWithValue("@WheelInPuddleDepthRearRight", data.WheelInPuddleDepthRearRight);
            parameters.AddWithValue("@SurfaceRumbleFrontLeft", data.SurfaceRumbleFrontLeft);
            parameters.AddWithValue("@SurfaceRumbleFrontRight", data.SurfaceRumbleFrontRight);
            parameters.AddWithValue("@SurfaceRumbleRearLeft", data.SurfaceRumbleRearLeft);
            parameters.AddWithValue("@SurfaceRumbleRearRight", data.SurfaceRumbleRearRight);
            parameters.AddWithValue("@TireSlipAngleFrontLeft", data.TireSlipAngleFrontLeft);
            parameters.AddWithValue("@TireSlipAngleFrontRight", data.TireSlipAngleFrontRight);
            parameters.AddWithValue("@TireSlipAngleRearLeft", data.TireSlipAngleRearLeft);
            parameters.AddWithValue("@TireSlipAngleRearRight", data.TireSlipAngleRearRight);
            parameters.AddWithValue("@TireCombinedSlipFrontLeft", data.TireCombinedSlipFrontLeft);
            parameters.AddWithValue("@TireCombinedSlipFrontRight", data.TireCombinedSlipFrontRight);
            parameters.AddWithValue("@TireCombinedSlipRearLeft", data.TireCombinedSlipRearLeft);
            parameters.AddWithValue("@TireCombinedSlipRearRight", data.TireCombinedSlipRearRight);
            parameters.AddWithValue("@SuspensionTravelMetersFrontLeft", data.SuspensionTravelMetersFrontLeft);
            parameters.AddWithValue("@SuspensionTravelMetersFrontRight", data.SuspensionTravelMetersFrontRight);
            parameters.AddWithValue("@SuspensionTravelMetersRearLeft", data.SuspensionTravelMetersRearLeft);
            parameters.AddWithValue("@SuspensionTravelMetersRearRight", data.SuspensionTravelMetersRearRight);
            parameters.AddWithValue("@CarOrdinal", Convert.ToInt32(data.CarOrdinal));
            parameters.AddWithValue("@CarClass", Convert.ToInt32(data.CarClass));
            parameters.AddWithValue("@CarPerformanceIndex", Convert.ToInt32(data.CarPerformanceIndex));
            parameters.AddWithValue("@DrivetrainType", Convert.ToInt32(data.DrivetrainType));
            parameters.AddWithValue("@NumCylinders", Convert.ToInt32(data.NumCylinders));    
            parameters.AddWithValue("@PositionX", data.PositionX);
            parameters.AddWithValue("@PositionY", data.PositionY);
            parameters.AddWithValue("@PositionZ", data.PositionZ);
            parameters.AddWithValue("@Speed", data.Speed);
            parameters.AddWithValue("@Power", data.Power);
            parameters.AddWithValue("@Torque", data.Torque);
            parameters.AddWithValue("@TireTempFl", data.TireTempFl);
            parameters.AddWithValue("@TireTempFr", data.TireTempFr);
            parameters.AddWithValue("@TireTempRl", data.TireTempRl);
            parameters.AddWithValue("@TireTempRr", data.TireTempRr);
            parameters.AddWithValue("@Boost", data.Boost);
            parameters.AddWithValue("@Fuel", data.Fuel);
            parameters.AddWithValue("@Distance", data.Distance);
            parameters.AddWithValue("@BestLapTime", data.BestLapTime);
            parameters.AddWithValue("@LastLapTime", data.LastLapTime);
            parameters.AddWithValue("@CurrentLapTime", data.CurrentLapTime);
            parameters.AddWithValue("@CurrentRaceTime", data.CurrentRaceTime);
            parameters.AddWithValue("@Lap", Convert.ToInt32(data.Lap));
            parameters.AddWithValue("@RacePosition", Convert.ToInt32(data.RacePosition));
            parameters.AddWithValue("@Accelerator", Convert.ToInt32(data.Accelerator));
            parameters.AddWithValue("@Brake", Convert.ToInt32(data.Brake));
            parameters.AddWithValue("@Clutch", Convert.ToInt32(data.Clutch));
            parameters.AddWithValue("@Handbrake", Convert.ToInt32(data.Handbrake));
            parameters.AddWithValue("@Gear", Convert.ToInt32(data.Gear));
            parameters.AddWithValue("@Steer", data.Steer);
            parameters.AddWithValue("@NormalDrivingLine", Convert.ToInt32(data.NormalDrivingLine));
            parameters.AddWithValue("@NormalAiBrakeDifference", Convert.ToInt32(data.NormalAiBrakeDifference));
            









        }

        public const string ConnectionString = "Server=192.168.0.136;Database=ForzaAnalysis;User Id=ForzaAnalysisUser;Password=ForzaAnalysisPass;Encrypt=No;";
        public const string InsertStatement = @"INSERT [dbo].[DataPacket] (
            [IsRaceOn]
           ,[TimestampMS]
           ,[EngineMaxRpm]
           ,[EngineIdleRpm]
           ,[CurrentEngineRpm]
           ,[AccelerationX]
           ,[AccelerationY]
           ,[AccelerationZ]
           ,[VelocityX]
           ,[VelocityY]
           ,[VelocityZ]
           ,[AngularVelocityX]
           ,[AngularVelocityY]
           ,[AngularVelocityZ]
           ,[Yaw]
           ,[Pitch]
           ,[Roll]
           ,[NormalizedSuspensionTravelFrontLeft]
           ,[NormalizedSuspensionTravelFrontRight]
           ,[NormalizedSuspensionTravelRearLeft]
           ,[NormalizedSuspensionTravelRearRight]
           ,[TireSlipRatioFrontLeft]
           ,[TireSlipRatioFrontRight]
           ,[TireSlipRatioRearLeft]
           ,[TireSlipRatioRearRight]
           ,[WheelRotationSpeedFrontLeft]
           ,[WheelRotationSpeedFrontRight]
           ,[WheelRotationSpeedRearLeft]
           ,[WheelRotationSpeedRearRight]
           ,[WheelOnRumbleStripFrontLeft]
           ,[WheelOnRumbleStripFrontRight]
           ,[WheelOnRumbleStripRearLeft]
           ,[WheelOnRumbleStripRearRight]
           ,[WheelInPuddleDepthFrontLeft]
           ,[WheelInPuddleDepthFrontRight]
           ,[WheelInPuddleDepthRearLeft]
           ,[WheelInPuddleDepthRearRight]
           ,[SurfaceRumbleFrontLeft]
           ,[SurfaceRumbleFrontRight]
           ,[SurfaceRumbleRearLeft]
           ,[SurfaceRumbleRearRight]
           ,[TireSlipAngleFrontLeft]
           ,[TireSlipAngleFrontRight]
           ,[TireSlipAngleRearLeft]
           ,[TireSlipAngleRearRight]
           ,[TireCombinedSlipFrontLeft]
           ,[TireCombinedSlipFrontRight]
           ,[TireCombinedSlipRearLeft]
           ,[TireCombinedSlipRearRight]
           ,[SuspensionTravelMetersFrontLeft]
           ,[SuspensionTravelMetersFrontRight]
           ,[SuspensionTravelMetersRearLeft]
           ,[SuspensionTravelMetersRearRight]
           ,[CarOrdinal]
           ,[CarClass]
           ,[CarPerformanceIndex]
           ,[DrivetrainType]
           ,[NumCylinders]
           ,[PositionX]
           ,[PositionY]
           ,[PositionZ]
           ,[Speed]
           ,[Power]
           ,[Torque]
           ,[TireTempFl]
           ,[TireTempFr]
           ,[TireTempRl]
           ,[TireTempRr]
           ,[Boost]
           ,[Fuel]
           ,[Distance]
           ,[BestLapTime]
           ,[LastLapTime]
           ,[CurrentLapTime]
           ,[CurrentRaceTime]
           ,[Lap]
           ,[RacePosition]
           ,[Accelerator]
           ,[Brake]
           ,[Clutch]
           ,[Handbrake]
           ,[Gear]
           ,[Steer]
           ,[NormalDrivingLine]
           ,[NormalAiBrakeDifference]
        ) Values (
            @IsRaceOn,
            @TimestampMS,
            @EngineMaxRpm,
            @EngineIdleRpm,
            @CurrentEngineRpm,
            @AccelerationX,
            @AccelerationY,
            @AccelerationZ,
            @VelocityX,
            @VelocityY,
            @VelocityZ,
            @AngularVelocityX,
            @AngularVelocityY,
            @AngularVelocityZ,
            @Yaw,
            @Pitch,
            @Roll,
            @NormalizedSuspensionTravelFrontLeft,
            @NormalizedSuspensionTravelFrontRight,
            @NormalizedSuspensionTravelRearLeft,
            @NormalizedSuspensionTravelRearRight,
            @TireSlipRatioFrontLeft,
            @TireSlipRatioFrontRight,
            @TireSlipRatioRearLeft,
            @TireSlipRatioRearRight,
            @WheelRotationSpeedFrontLeft,
            @WheelRotationSpeedFrontRight,
            @WheelRotationSpeedRearLeft,
            @WheelRotationSpeedRearRight,
            @WheelOnRumbleStripFrontLeft,
            @WheelOnRumbleStripFrontRight,
            @WheelOnRumbleStripRearLeft,
            @WheelOnRumbleStripRearRight,
            @WheelInPuddleDepthFrontLeft,
            @WheelInPuddleDepthFrontRight,
            @WheelInPuddleDepthRearLeft,
            @WheelInPuddleDepthRearRight,
            @SurfaceRumbleFrontLeft,
            @SurfaceRumbleFrontRight,
            @SurfaceRumbleRearLeft,
            @SurfaceRumbleRearRight,
            @TireSlipAngleFrontLeft,
            @TireSlipAngleFrontRight,
            @TireSlipAngleRearLeft,
            @TireSlipAngleRearRight,
            @TireCombinedSlipFrontLeft,
            @TireCombinedSlipFrontRight,
            @TireCombinedSlipRearLeft,
            @TireCombinedSlipRearRight,
            @SuspensionTravelMetersFrontLeft,
            @SuspensionTravelMetersFrontRight,
            @SuspensionTravelMetersRearLeft,
            @SuspensionTravelMetersRearRight,
            @CarOrdinal,
            @CarClass,
            @CarPerformanceIndex,
            @DrivetrainType,
            @NumCylinders,
            @PositionX,
            @PositionY,
            @PositionZ,
            @Speed,
            @Power,
            @Torque,
            @TireTempFl,
            @TireTempFr,
            @TireTempRl,
            @TireTempRr,
            @Boost,
            @Fuel,
            @Distance,
            @BestLapTime,
            @LastLapTime,
            @CurrentLapTime,
            @CurrentRaceTime,
            @Lap,
            @RacePosition,
            @Accelerator,
            @Brake,
            @Clutch,
            @Handbrake,
            @Gear,
            @Steer,
            @NormalDrivingLine,
            @NormalAiBrakeDifference
)";
    }
}
