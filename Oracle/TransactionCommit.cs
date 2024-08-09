/*
* 간단한 회원가입 기능을 만들 다 Transaction 예외처리 부분을 설명합니다.
* INSERT, UPDATE, DELETE는 영구적으로 적용하려면 Commit를 해주어야 합니다.
* 
*/


private void btnRegisterUser_Click(object sender, EventArgs e)
{
    string userId = tbID.Text;   // ID 입력값
    string password = tbPwd.Text; // 비밀번호 입력값

    if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(password))
    {
        MessageBox.Show("ID와 비밀번호를 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    using (OracleConnection connection = new OracleConnection(connectionString))
    {
        OracleTransaction transaction = null; // 트랜잭션 레퍼런스 선언 try 이후 catch 부분에도 Scope가 적용되려면 try전에 선언 되어야 함!!!
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            string query = "INSERT INTO Member (ID, PWD) VALUES (:id, :pwd)";

            using (OracleCommand command = new OracleCommand(query, connection))
            {
                command.Transaction = transaction;  // 트랜잭션 설정
                command.Parameters.Add(new OracleParameter("id", userId));
                command.Parameters.Add(new OracleParameter("pwd", password)); // 실제 사용 시 비밀번호는 해싱하여 저장해야 합니다.

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // 모든 쿼리가 성공적으로 실행되면 커밋
                    transaction.Commit();
                    MessageBox.Show("회원가입이 성공적으로 완료되었습니다.", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    transaction.Rollback(); //실패시는 롤백
                    MessageBox.Show("회원가입에 실패하였습니다. 다시 시도해주세요.", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        catch (Exception ex)
        {
            if (transaction != null)
            {
                try
                {
                    transaction.Rollback(); // 오류 발생 시 롤백
                }
                catch (Exception rollbackEx)  //롤백 오류시 적용, 현재는 오류 메시지 출력 형태로만 구성
                {
                    MessageBox.Show($"롤백 중 오류 발생: {rollbackEx.Message}", "롤백 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            MessageBox.Show($"오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
